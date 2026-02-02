using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public class PlayersFactory : MonoBehaviour, IFactory<ControlPlayer>
{
    [SerializeField] private ControlPlayer _playerPrefab;

    private IObjectResolver _objectResolver;

    [Inject]
    public void Construct(IObjectResolver objectResolver)
    {
        _objectResolver = objectResolver;
    }

    public ControlPlayer Create()
    {
        ControlPlayer newPlayer = Instantiate(_playerPrefab);
        Debug.Log($"{_objectResolver} {newPlayer}");
        _objectResolver.Inject(newPlayer);
        return newPlayer;
    }
}
