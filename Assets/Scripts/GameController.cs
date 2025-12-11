using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject escapeScreen;
    private bool _wasEscapePressed;
    private const int LevelSelectSceneIndex = 1;
    private InputAction _escapeKey;

    void Awake()
    {
        _escapeKey = InputSystem.actions["Cancel"];
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_escapeKey.triggered && !_wasEscapePressed)
        {
            _wasEscapePressed = true;
            escapeScreen.SetActive(true);
        }
    }
    
    public void ReturnToLevelSelect()
    {
        SceneManager.LoadScene(LevelSelectSceneIndex);
    }

    public void ReturnToGame()
    {
        _wasEscapePressed = false;
        escapeScreen.SetActive(false);
    }

    public void SpawnCaveToNextLevel(int level)
    {
        // load scene with cave
    }
}
