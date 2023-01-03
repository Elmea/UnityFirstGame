using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInfo))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float acceleration = 0.5f;

    [SerializeField] float jumpPower;

    PlayerInfo info;

    private Rigidbody rigidbody;

    private Vector3 velocity;
    private Vector3 rotation;

    private bool goLeft;
    private bool goRight;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        info = GetComponent<PlayerInfo>();
        velocity = new Vector3();
        rotation = new Vector3(0, 90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Vector3 ColisionVec = collision.GetContact(0).point - transform.position;
            PlayerInfo.haveControl = true;
            if (ColisionVec.y < 0.5f)
                info.isGrounded = true;
        }
    }

    public void moveRight(InputAction.CallbackContext context)
    {
        if (context.started && PlayerInfo.haveControl)
        {
            goRight = true;
            rotation.y = 90f;
        }

        if (context.canceled)
            goRight = false;
    }

    public void moveLeft(InputAction.CallbackContext context)
    {
        if (context.started && PlayerInfo.haveControl)
        {
            goLeft = true;
            rotation.y = 270f;
        }


        if (context.canceled)
            goLeft = false;
    }

    public void dojump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (info.isGrounded && PlayerInfo.haveControl)
            {
                rigidbody.AddForce(new Vector3(0, jumpPower, 0));
                info.isGrounded = false;
            }
        }
    }

    public void godMod(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayerInfo.godMod = !PlayerInfo.godMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfo.haveControl)
        {
            if (goLeft)
            {
                if (info.isGrounded)
                {
                    if (velocity.x > -speed)
                        velocity.x -= acceleration;
                }
                else
                {
                    if (velocity.x > -speed / 2f)
                        velocity.x -= acceleration;
                }
            }

            if (goRight)
            {
                if (info.isGrounded)
                {
                    if (velocity.x < speed)
                        velocity.x += acceleration;
                }
                else
                {
                    if (velocity.x < speed / 2f)
                        velocity.x += acceleration;
                }
            }

            if (!goLeft && !goRight)
            {
                if (info.isGrounded)
                {
                    if (velocity.x > 0)
                        velocity.x -= 0.5f;

                    if (velocity.x < 0)
                        velocity.x += 0.5f;

                    if (velocity.x < 0.5f && velocity.x > -0.5f)
                        velocity.x = 0;
                }
                else
                {
                    if (velocity.x > 0)
                        velocity.x -= 0.025f;
                    if (velocity.x < 0)
                        velocity.x += 0.025f;
                }
            }

            velocity.y = rigidbody.velocity.y;

            rigidbody.velocity = velocity;
        }

        Quaternion r = new Quaternion();
        r.eulerAngles = rotation;
        transform.rotation = r;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
    }
}
