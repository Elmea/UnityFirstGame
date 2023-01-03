using UnityEngine;

public class Charging : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField] GameObject player;
    [SerializeField] GameObject frontPoint;
    [SerializeField] bool canFall = false;

    private Rigidbody rigidbody;

    private Vector3 velocity;
    private Vector3 rotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocity = new Vector3();
        rotation = new Vector3(0, 270f, 0);
    }

    public void Charge()
    {
        if (player.transform.position.x > transform.position.x)
        {
            if (velocity.x < speed)
                velocity.x += 0.1f;

            rotation.y = 90f;
        }
        else
        {
            if (velocity.x > -speed)
                velocity.x -= 0.1f;

            rotation.y = 270f;
        }

        if (!Physics.Raycast(frontPoint.transform.position, new Vector3(0, -0.2f, 0), 1f) && !canFall)
            velocity.x = 0;

        Debug.DrawRay(frontPoint.transform.position, new Vector3(0, -0.2f, 0), Color.green);


        Quaternion r = new Quaternion();
        r.eulerAngles = rotation;
        transform.rotation = r;

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }
}