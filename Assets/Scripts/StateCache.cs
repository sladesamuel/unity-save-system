using System;
using System.Collections.Generic;

public class StateCache
{
    private readonly Dictionary<string, object> cache =
        new Dictionary<string, object>(StringComparer.Ordinal);

    public StateCache()
    {
        UnityEngine.Debug.Log("StateCache.ctor()");
    }

    public object Get(string key)
    {
        cache.TryGetValue(key, out object value);
        return value;
    }

    public void Store(string key, object value) => cache[key] = value;
}
