using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    [SerializeField] private PlayersFactory _playersFactory;
    [SerializeField] private WindowsManager _windowManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Container>(Lifetime.Singleton).As<IObjectResolver>();
        builder.Register<PlayerInput>(Lifetime.Singleton).As<IMoveInput>();
        builder.RegisterComponentInNewPrefab<PlayersFactory>(_playersFactory, Lifetime.Singleton);
        builder.RegisterComponentInNewPrefab<WindowsManager>(_windowManager, Lifetime.Singleton).DontDestroyOnLoad();
    }

}
