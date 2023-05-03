using System;
using System.Collections.Generic;
using System.Linq;

public class StateCache
{
    private readonly Dictionary<string, object> cache =
        new Dictionary<string, object>(StringComparer.Ordinal);

    public IReadOnlyCollection<KeyValuePair<string, object>> GetAllCacheEntries() => cache.ToArray();

    public void PreloadCache(IEnumerable<KeyValuePair<string, object>> entries)
    {
        cache.Clear();

        foreach (var entry in entries)
        {
            cache.Add(entry.Key, entry.Value);
        }
    }

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
