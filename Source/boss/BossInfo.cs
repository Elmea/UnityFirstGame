using UnityEngine;

public class BossInfo : MonoBehaviour
{
    public int life = 3;

    [SerializeField] GameObject bumperPrefab;
    [SerializeField] GameObject bumperpos;

    private void Update()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false);
            GameObject bumper = Instantiate(bumperPrefab, bumperpos.transform.position, new Quaternion());
            Bumper bumperComp = bumper.GetComponent<Bumper>();
            bumperComp.bumpPower.y = 1500;
        }
    }
}
