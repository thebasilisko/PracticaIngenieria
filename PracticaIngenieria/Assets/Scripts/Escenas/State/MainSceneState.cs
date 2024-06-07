using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneState : IGameState
{
    private bool reloadScene;

    public MainSceneState(bool reloadScene = true)
    {
        this.reloadScene = reloadScene;
    }

    public void EnterState(GameManager gameManager)
    {
        if (reloadScene)
        {
            SceneManager.LoadScene("MainScene");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            GameManager.Instance.pauseMenuUI = GameObject.Find("PauseMenuUI");
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public void UpdateState(GameManager gameManager)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.SetState(new PauseState());
        }
        if (gameManager.PlayerHasWon())
        {
            gameManager.SetState(new WinState());
        }
        if (gameManager.PlayerHasLost())
        {
            gameManager.SetState(new LooseState());
        }
    }

    public void ExitState(GameManager gameManager)
    {
        if (GameManager.Instance.pauseMenuUI != null)
        {
            GameManager.Instance.pauseMenuUI.SetActive(false);
        }
    }
}

