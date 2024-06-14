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
        if (GameManager.Instance.controlsUI != null)
        {
            GameManager.Instance.controlsUI.SetActive(false);
        }
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.controlsUI.activeSelf)
        {
            gameManager.SetState(new MainSceneState());
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
