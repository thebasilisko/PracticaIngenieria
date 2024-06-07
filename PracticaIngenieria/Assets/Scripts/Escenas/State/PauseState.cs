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
        }
        Time.timeScale = 0f; // Pausa el juego
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1f; // Reanuda el juego
            gameManager.SetState(new MainSceneState(false)); // Cambia el estado sin recargar la escena
        }
    }

    public void ExitState(GameManager gameManager)
    {
        Debug.Log("Exiting PauseState");
        if (GameManager.Instance.pauseMenuUI != null)
        {
            GameManager.Instance.pauseMenuUI.SetActive(false);
        }
    }
}

