using Mirror.Examples.CharacterSelection;
using UnityEngine;
using VContainer;

public class ServiceLocator : MonoBehaviour
{
    [SerializeField] private NetMain _network;
    private static ServiceLocator _instance;
    public static ServiceLocator Instance => _instance;

    public IMoveInput MoveInput { get; private set; }
    public WindowsManager WindowsManager { get; private set; }
    public NetMain GameNetwork { get => _network; }

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
