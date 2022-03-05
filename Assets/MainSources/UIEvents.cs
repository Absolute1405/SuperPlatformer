using pEventBus;
public struct InitializeBarEvent : IEvent
{
    public int MaxValue { get; }
    public InitializeBarEvent(int maxvalue)
    {
        MaxValue = maxvalue;
    }
}
public struct RefreshBarEvent : IEvent
{
    public int Value { get; }
    public RefreshBarEvent(int value)
    {
        Value = value;
    }
}