using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bumper : MonoBehaviour
{
    public Vector3 bumpPower;
    [SerializeField] bool playerOnly;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void bump(Collision collision)
    {
        if (collision.GetContact(0).point.y > 0)
        {
            Rigidbody body = collision.collider.gameObject.GetComponent<Rigidbody>();
            PlayerInfo info = collision.collider.gameObject.GetComponent<PlayerInfo>();

            body.AddForce(bumpPower);
            info.isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playerOnly)
        {
            if (collision.collider.gameObject.tag == "Player")
            {
                bump(collision);
            }
        }
        else
        {
            bump(collision);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}