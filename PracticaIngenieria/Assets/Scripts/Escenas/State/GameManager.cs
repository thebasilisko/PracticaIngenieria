using UnityEngine;

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
            Debug.Log("GameManager instance created");
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate GameManager instance destroyed");
        }
    }

    private void Start()
    {
        if (controlsUI != null)
        {
            controlsUI.SetActive(false); // Desactiva el menú de controles al inicio si está asignado
            Debug.Log("Controls UI deactivated");
        }
        else
        {
            Debug.LogWarning("Controls UI is not assigned!");
        }

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Debug.Log("PauseMenuUI is assigned");
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }

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
        if (currentState != null)
        {
            currentState.ExitState(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.EnterState(this);
        }
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





