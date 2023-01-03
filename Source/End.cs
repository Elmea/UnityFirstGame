using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    private void Start()
    {
        particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo.reachEnd = true;
            PlayerInfo.haveControl = false;
            particle.Play();
        }
    }
}
