using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        GameManager.Instance.SetState(new MainSceneState());
    }

    public void OnControlsButtonClicked()
    {
        GameManager.Instance.controlsUI.SetActive(true);
        GameManager.Instance.mainMenuUI.SetActive(false);
    }

    public void OnBackButtonClicked()
    {
        GameManager.Instance.controlsUI.SetActive(false);
        GameManager.Instance.mainMenuUI.SetActive(true);
    }
}

