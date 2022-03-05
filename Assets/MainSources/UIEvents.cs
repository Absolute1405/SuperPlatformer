using pEventBus;
public struct PlayerHealthBarEvent : IEvent
{
    public int Value { get; }
    public int MaxValue { get; }

    public PlayerHealthBarEvent(int value, int maxValue)
    {
        Value = value;
        MaxValue = maxValue;
    }
}

public struct PlayerStaminaBarEvent : IEvent
{
    public int Value { get; }
    public int MaxValue { get; }

    public PlayerStaminaBarEvent(int value, int maxValue)
    {
        Value = value;
        MaxValue = maxValue;
    }
}
public struct PlayerSleepBarEvent : IEvent
{
    public int Value { get; }
    public int MaxValue { get; }

    public PlayerSleepBarEvent(int value, int maxValue)
    {
        Value = value;
        MaxValue = maxValue;
    }
}