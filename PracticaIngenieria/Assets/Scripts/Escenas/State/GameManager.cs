using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject mainMenuUI;
    public GameObject controlsUI;
    public GameObject pauseMenuUI;

    private IGameState currentState;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameManager).ToString());
                    instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetState(new MainMenuState());

    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void SetState(IGameState newState)
    {
        Debug.Log($"Changing state from {currentState?.GetType().Name} to {newState.GetType().Name}");
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        currentState.EnterState(this);
    }

    public bool PlayerHasLost()
    {
        // Implementar la lógica para verificar si el jugador ha perdido
        return false;
    }

    public bool PlayerHasWon()
    {
        // Implementar la lógica para verificar si el jugador ha ganado
        return false;
    }
}


