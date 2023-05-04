using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class GameData
{
    public string dataTypeName;
    public object data;
}

public class StateCache
{
    private readonly Dictionary<string, GameData> cache =
        new Dictionary<string, GameData>(StringComparer.Ordinal);

    public IReadOnlyCollection<KeyValuePair<string, GameData>> GetAllCacheEntries() => cache.ToArray();

    public void PreloadCache(IEnumerable<KeyValuePair<string, GameData>> entries)
    {
        cache.Clear();

        foreach (var entry in entries)
        {
            cache.Add(entry.Key, entry.Value);
        }
    }

    public void Store(IPreserveState instance)
    {
        var state = instance.GetState();
        cache[instance.ObjectId] = new GameData
        {
            dataTypeName = state.GetType().FullName,
            data = state
        };
    }

    public void Store<TState>(IPreserveState<TState> instance)
    {
        Store((IPreserveState)instance);
    }

    public void Load<TState>(IPreserveState<TState> instance)
    {
        if (cache.TryGetValue(instance.ObjectId, out var entry))
        {
            instance.LoadState((TState)entry.data);
        }
    }

    public void Load(IPreserveState instance)
    {
        if (cache.TryGetValue(instance.ObjectId, out var entry))
        {
            instance.LoadState(entry.data);
        }
    }
}
