using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Container>(Lifetime.Singleton).As<IObjectResolver>();
        builder.Register<PlayerInput>(Lifetime.Singleton).As<IMoveInput>();
    }

}
