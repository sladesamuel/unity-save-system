public interface ICacheable<TState>
{
    string ObjectId { get; }

    TState GetState();
    void LoadState(TState state);
}
