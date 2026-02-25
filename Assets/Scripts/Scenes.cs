using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
//UnityEngine.SceneManagement.SceneManager;

public class Scenes : MonoBehaviour
{
    public void ShowlevelScene()
    {
        NetworkManager.singleton.ServerChangeScene("GameScene");
    }

    public void ShowMenuScene()
    {
        NetworkManager.singleton.ServerChangeScene("MainMenu");
    }
}
