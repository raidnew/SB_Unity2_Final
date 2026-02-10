using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class ServiceLocator : MonoBehaviour
{
    private static ServiceLocator _instance;
    public static ServiceLocator Instance => _instance;

    public IMoveInput MoveInput { get; private set; }
    public WindowsManager WindowsManager { get; private set; }

    [Inject]
    public void Construct(IMoveInput playerInput)
    {
        MoveInput = playerInput;
    }

    private void Awake()
    {
        _instance = this;
    }
}
