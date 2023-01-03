using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Weakpoint : MonoBehaviour
{
    [SerializeField] Vector3 bumpPower;
    [SerializeField] GameObject boss;

    BossInfo info;

    private void Start()
    {
        info = boss.GetComponent<BossInfo>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody body = collision.gameObject.GetComponent<Rigidbody>();
            PlayerInfo playerInfo = collision.collider.gameObject.GetComponent<PlayerInfo>();
            PlayerInfo.haveControl = false;

            playerInfo.isGrounded = false;
            body.AddForce(bumpPower);
            info.life--;
            gameObject.SetActive(false);
        }
    }
}
