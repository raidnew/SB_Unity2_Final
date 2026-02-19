using UnityEngine;
using UnityEngine.SceneManagement;
//UnityEngine.SceneManagement.SceneManager;

public class Scenes : MonoBehaviour
{

    public void ShowlevelScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
