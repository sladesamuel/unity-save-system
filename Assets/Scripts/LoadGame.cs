using UnityEngine;
using Zenject;

public class LoadGame : MonoBehaviour
{
    [Inject]
    public SaveDataReader reader;

    public GameLoader loader;

    public void Load()
    {
        var saveData = reader.Read();
        if (saveData != null)
        {
            // We need to farm off the loading logic to a component that is attached
            // to a root-level object, as it needs to temporarily use DontDestroyOnLoad
            // See: https://gamedev.stackexchange.com/q/199107/8792
            loader.LoadGame(saveData);
        }
    }

}
