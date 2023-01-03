using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LifeUp : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;

    private float originY;

    private float time;

    private void Start()
    {
        originY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInfo.life++;

            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        time += Time.deltaTime;

        currPos.y = curve.Evaluate(time)/3f;

        currPos.y += originY;

        transform.position = currPos;
    }
}