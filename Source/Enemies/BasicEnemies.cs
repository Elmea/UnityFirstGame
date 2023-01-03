using UnityEngine;

[RequireComponent(typeof(Roaming))]
public class BasicEnemies : MonoBehaviour
{
    Roaming roaming;

    // Start is called before the first frame update
    void Start()
    {
        roaming = GetComponent<Roaming>();
    }

    // Update is called once per frame
    void Update()
    {
        roaming.walk();
    }
}
