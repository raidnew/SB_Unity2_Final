using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class ServiceLocator : MonoBehaviour
{
    private static ServiceLocator _instance;
    public static ServiceLocator Instance => _instance;

    public IMoveInput MoveInput { get; private set; }
    public WindowsManager WindowsManager { get; private set; }

    public Scenes Scenes { get; private set; }

    [Inject]
    public void Construct(IMoveInput playerInput, WindowsManager windowManager, Scenes scenes)
    {
        MoveInput = playerInput;
        WindowsManager = windowManager;
        Scenes = scenes;
    }

    private void Awake()
    {
        _instance = this;
    }
}
