using UnityEngine;

public class TestDebugLog : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("TestDebugLog Awake called");
    }

    private void Start()
    {
        Debug.Log("TestDebugLog Start called");
    }
}
