using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Killable : MonoBehaviour
{
    [SerializeField] float bumpPower = 500;
    [SerializeField] float dropRate;
    [SerializeField] GameObject objectToDrop;


    public int life = 1;
    GameObject parent;

// Start is called before the first frame update
    void Start()     
    {
        parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            life--;
            Rigidbody body = other.attachedRigidbody;
            body.AddForce(new Vector3(0, bumpPower, 0));

            
        }

        if (life <= 0)
        {

            if (objectToDrop != null)
            {
                if (Random.Range(0f, 1f) <= dropRate)
                {
                    Instantiate(objectToDrop, parent.transform.position + new Vector3(0, 0.6f, 0), new Quaternion());
                }
            }

            parent.SetActive(false);
        }
    }
}
