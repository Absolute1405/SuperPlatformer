using System;

public class Stamina
{
    private readonly int _maxValue;

    public event Action<int> ValueChanged;
    public int Value { get; protected set; }
    public Stamina (int maxValue)
    {
        if (maxValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        
        _maxValue = maxValue;
        Value = _maxValue;
    }

    public void SetFull()
    {
        Value = _maxValue;
        ValueChanged?.Invoke(Value);
    }

    public void Decrease(int x)
    {
        if (Value < x)
        {
            Value = 0;
            return;
        }

        Value -= x;
        ValueChanged?.Invoke(Value);
    }
}
