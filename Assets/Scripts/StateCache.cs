using System;
using System.Collections.Generic;

public class StateCache
{
    private readonly Dictionary<string, object> cache =
        new Dictionary<string, object>(StringComparer.Ordinal);

    public void Store<TState>(ICacheable<TState> instance)
    {
        cache[instance.ObjectId] = instance.GetState();
    }

    public void Load<TState>(ICacheable<TState> instance)
    {
        if (cache.TryGetValue(instance.ObjectId, out object state))
        {
            instance.LoadState((TState)state);
        }
    }
}
