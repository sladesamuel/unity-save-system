using System;
using System.Collections.Generic;
using System.Linq;

public class StateCache
{
    private readonly Dictionary<string, object> cache =
        new Dictionary<string, object>(StringComparer.Ordinal);

    public IReadOnlyCollection<KeyValuePair<string, object>> GetAllCacheEntries() => cache.ToArray();

    public void Store(IPreserveState instance)
    {
        cache[instance.ObjectId] = instance.GetState();
    }

    public void Store<TState>(IPreserveState<TState> instance)
    {
        Store((IPreserveState)instance);
    }

    public void Load<TState>(IPreserveState<TState> instance)
    {
        if (cache.TryGetValue(instance.ObjectId, out object state))
        {
            instance.LoadState((TState)state);
        }
    }

    public void Load(IPreserveState instance)
    {
        if (cache.TryGetValue(instance.ObjectId, out object state))
        {
            instance.LoadState(state);
        }
    }
}
