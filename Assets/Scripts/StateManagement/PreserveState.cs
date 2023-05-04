using UnityEngine;
using Zenject;

public class PreserveState : MonoBehaviour
{
    [Inject]
    public StateCache cache;

    void Awake()
    {
        var instances = GetComponents<IPreserveState>();
        foreach (var instance in instances)
        {
            cache.Load(instance);
        }
    }

    void OnDestroy()
    {
        var instances = GetComponents<IPreserveState>();
        foreach (var instance in instances)
        {
            cache.Store(instance);
        }
    }
}
