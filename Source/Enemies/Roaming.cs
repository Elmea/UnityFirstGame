using UnityEngine;

class Roaming : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject frontPoint;

    private Rigidbody rigidbody;

    private Vector3 velocity;
    private Vector3 rotation;

    private bool goRight = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        velocity = new Vector3();
        rotation = new Vector3(0, 270f, 0);
    }

    private void turn()
    {
        if (goRight)
        {
            rotation.y = 270f;
            goRight = false;
        }
        else
        {
            rotation.y = 90f;
            goRight = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 ColisionVec = collision.GetContact(0).point - transform.position;
        if (ColisionVec.x > 0)
            turn();
        else if (ColisionVec.x < 0)
            turn();
    }

    public void walk()
    {
        if (velocity.x > speed)
            velocity.x = speed;

        if (velocity.x < -speed)
            velocity.x = -speed;

        if (goRight)
        {
            if (velocity.x < speed)
                velocity.x++;
        }
        else
        {
            if (velocity.x > -speed)
                velocity.x--;
        }

        if (!Physics.Raycast(frontPoint.transform.position, new Vector3(0, -0.2f, 0), 0.1f))
            turn();

        Debug.DrawRay(frontPoint.transform.position, new Vector3(0, -0.2f, 0), Color.green);
            
        velocity.y = rigidbody.velocity.y;  
        rigidbody.velocity = velocity;

        Quaternion r = new Quaternion();
        r.eulerAngles = rotation;
        transform.rotation = r;
    }
}

