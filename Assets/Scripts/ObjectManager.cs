using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager _instance;
    public static ObjectManager Instance => _instance;

    public IMoveInput MoveInput { get; private set; }

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
