using UnityEngine;
using VContainer;

public class Game : MonoBehaviour
{

    private WindowsManager _windowsManager;

    [Inject]
    public void Construct(WindowsManager windowsManager)
    {
        _windowsManager = windowsManager;
    }

    private void Start()
    {
        _windowsManager.OpenWindow(Window.Main);
    }
}
