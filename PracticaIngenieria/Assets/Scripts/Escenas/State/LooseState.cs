using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        SceneManager.LoadScene("Lose");
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
        // Lógica para salir de la escena de derrota si es necesario
    }
}
