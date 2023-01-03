using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isActive)
            {
                isActive = true;
                PlayerInfo.respawnPoint.x = transform.position.x;
                PlayerInfo.respawnPoint.y = transform.position.y + 1f;
                particle.Play();
            }
        }
    }
}