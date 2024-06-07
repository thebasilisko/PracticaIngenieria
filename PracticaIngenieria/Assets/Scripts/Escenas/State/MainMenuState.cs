using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        SceneManager.LoadScene("MainMenu");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            // Configurar las referencias de UI
            GameManager.Instance.mainMenuUI = GameObject.Find("MainMenuUI");
            GameManager.Instance.controlsUI = GameObject.Find("ControlsUI");
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.SetState(new MainSceneState());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.controlsUI.SetActive(true);
        }
    }

    public void ExitState(GameManager gameManager)
    {
        // Desactivar las referencias de UI si es necesario
        if (GameManager.Instance.controlsUI != null)
        {
            GameManager.Instance.controlsUI.SetActive(false);
        }
    }
}
