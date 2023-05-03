using UnityEngine;
using Zenject;

public class BindingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StateCache>().AsSingle();
        Container.Bind<SceneSwitcher>().AsSingle();
        Container.Bind<SaveDataWriter>().AsTransient();
        Container.Bind<SaveDataReader>().AsTransient();
    }
}
