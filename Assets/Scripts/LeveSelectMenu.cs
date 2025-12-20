using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{

    private const int Act1Index = 2;
    private const int Act2Index = 3;
    
    public void StartAct1()
    {
        SceneManager.LoadScene(Act1Index);
    }
    
    public void StartAct2()
    {
        SceneManager.LoadScene(Act2Index);
    }

}
