using UnityEngine;
using VContainer;

public class LevelManager : MonoBehaviour
{

    private PlayersFactory _playersFactory;

    [Inject]
    public void Construct(PlayersFactory playerFactory)
    {
        _playersFactory = playerFactory;
    }

    void Start()
    {
        //ControlPlayer player = _playersFactory.Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
