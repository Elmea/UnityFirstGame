using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInfo))]
public class PlayerCollision : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("Main");
    }

    public void GotHited()
    {
        PlayerInfo.life--;
        Respawn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!PlayerInfo.godMod)
        {
            switch (collision.gameObject.tag)
            {
                case "LetalObstacle":
                    GotHited();
                    break;

                case "Enemy":
                    Vector3 ColisionVec = collision.GetContact(0).point - transform.position;
                    if (ColisionVec.y > 0)
                    {
                        GotHited();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
