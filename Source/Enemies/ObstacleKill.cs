using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObstacleKill : MonoBehaviour
{
    Killable killable;

    private void Start()
    {
        killable = GetComponentInChildren<Killable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LetalObstacle")
        {
            gameObject.SetActive(false);
        }
    }
}
