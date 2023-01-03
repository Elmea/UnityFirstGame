using UnityEngine;

[RequireComponent(typeof(Roaming))]
[RequireComponent(typeof(Charging))]
public class Runner : MonoBehaviour
{
    Roaming roaming;
    Charging charging;
    DetectPlayer detection;

    [SerializeField] GameObject detectionZone;
    [SerializeField] GameObject frontPoint;

    public bool isCharging;

    // Start is called before the first frame update
    void Start()
    {
        roaming = GetComponent<Roaming>();
        charging = GetComponent<Charging>();
        detection = detectionZone.GetComponent<DetectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detection != null)
        {
            if (detection.playerInZone)
            {
                charging.Charge();
                isCharging = true;
            }
            else
            {
                roaming.walk();
                isCharging = false;
            }
        }
    }
}
