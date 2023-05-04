using Zenject;

public class BindingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StateCache>().AsSingle();
        Container.Bind<SceneSwitcher>().AsSingle();

        Container.Bind<ISaveDataWriter>()
            .To<JsonSaveDataWriter>()
            .AsTransient();

        Container.Bind<ISaveDataReader>()
            .To<JsonSaveDataReader>()
            .AsTransient();
    }
}
