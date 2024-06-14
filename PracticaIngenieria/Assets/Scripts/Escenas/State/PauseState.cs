using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        Debug.Log("Entering PauseState");
        if (GameManager.Instance.pauseMenuUI != null)
        {
            GameManager.Instance.pauseMenuUI.SetActive(true);
            Debug.Log("Pause menu activated");
        }
        Time.timeScale = 0f; // Pausa el juego
        Debug.Log("Time.timeScale set to 0");
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed in PauseState");
            gameManager.SetState(new MainSceneState(false)); // Cambio el estado sin recargar la escena
        }
    }

    public void ExitState(GameManager gameManager)
    {
        Debug.Log("Exiting PauseState");
        if (GameManager.Instance.pauseMenuUI != null)
        {
            GameManager.Instance.pauseMenuUI.SetActive(false);
            Debug.Log("Pause menu deactivated");
        }
        Time.timeScale = 1f; // Reanuda el juego
        Debug.Log("Time.timeScale set to 1");
    }

}

