using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        SceneManager.LoadScene("Win");
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.anyKeyDown)
        {
            gameManager.SetState(new MainMenuState());
        }
    }

    public void ExitState(GameManager gameManager)
    {
        // Lógica para salir de la escena de victoria si es necesario
    }
}

