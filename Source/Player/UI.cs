using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInfo))]
public class UI : MonoBehaviour
{
    [SerializeField] Text lifeText;
    [SerializeField] RawImage lifeImage;

    [SerializeField] Text gameOverText;
    [SerializeField] Text gameOverText2;

    [SerializeField] Text winText;
    [SerializeField] Text winText2;
    [SerializeField] Text winText3;

    [SerializeField] Text quit;
    [SerializeField] Text quitUnderLife;

    public void Win()
    {
        winText.gameObject.SetActive(true);
        winText2.gameObject.SetActive(true);
        winText3.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

        lifeText.gameObject.SetActive(false);
        lifeImage.gameObject.SetActive(false);
        quitUnderLife.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText2.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

        lifeText.gameObject.SetActive(false);
        lifeImage.gameObject.SetActive(false);
        quitUnderLife.gameObject.SetActive(false);

    }

    private void Update()
    {
        lifeText.text = $"{PlayerInfo.life}";
    }
}
