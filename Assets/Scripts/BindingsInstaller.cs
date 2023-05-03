using UnityEngine;
using Zenject;

public class BindingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Install bindings...");

        Container.Bind<StateCache>()
            .AsSingle();
    }
}
