using System;

public class Stat 
{
    public int Value { get; protected set; }

    public event Action Abandoned;
    public int MaxValue { get; }
    public event Action<int> ValueChanged; 

    public Stat(int maxValue)
    {
        if (maxValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        MaxValue = maxValue;
        Value = MaxValue;
        if (Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(Value));
    }

    public void Decrease(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value -= value;

        if (Value <= 0)
        {
            Abandoned?.Invoke();
            Value = 0;
        }

        ValueChanged?.Invoke(Value);
    }

    public void Increase(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value += value;

        if (Value > MaxValue)
        {
            Value = MaxValue;
        }

        ValueChanged?.Invoke(Value);
    }

    public void SetFull()
    {
        Value = MaxValue;
        ValueChanged?.Invoke(Value);
    }
}