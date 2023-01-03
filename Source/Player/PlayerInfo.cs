using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] bool useCheckpoint = true; //use checkpoint and start point
    public bool isGrounded;

    public static bool godMod = false;
    public static int life = 5;
    public static bool haveControl;
    public static Vector3 respawnPoint = new Vector3(-5, 1, 0);
    public static bool reachEnd;

    private void Start()
    {
        if (useCheckpoint)
            transform.position = respawnPoint;

        reachEnd = false;
    }
}
