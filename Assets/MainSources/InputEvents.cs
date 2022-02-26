using pEventBus;

public struct InputHorizontalEvent : IEvent
{
    public float Value { get; }
    public InputHorizontalEvent(float value)
    {
        Value = value;
    }
}
public struct InputSpaceEvent : IEvent { }
public struct InputLMouseEvent : IEvent { }