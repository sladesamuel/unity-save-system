public interface IPreserveState
{
    string ObjectId { get; }

    object GetState();
    void LoadState(object state);
}

public interface IPreserveState<TState> : IPreserveState
{
    new TState GetState();
    void LoadState(TState state);
}
