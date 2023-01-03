using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DetectPlayer : MonoBehaviour
{
    public bool playerInZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerInZone = false;
    }
}
