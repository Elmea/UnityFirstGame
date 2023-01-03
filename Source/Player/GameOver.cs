using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInfo))]
public class GameOver : MonoBehaviour
{
    [SerializeField] UI ui;

    private bool canRestart = false;

    public void Restart(InputAction.CallbackContext context)
    {
        if (canRestart)
        {
            PlayerInfo.respawnPoint = new Vector3(-5, 1, 0);
            PlayerInfo.life = 5;

            SceneManager.LoadScene("Main");
        }
    }

    public void Quit(InputAction.CallbackContext context)
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    private void Update()
    { 
        if (PlayerInfo.life <= 0)
        {
            ui.GameOver();

            gameObject.SetActive(false);
            canRestart = true;
        }

        if (PlayerInfo.reachEnd)
        {
            ui.Win();
            canRestart = true;
            PlayerInfo.haveControl = false;
        }
    }
}
