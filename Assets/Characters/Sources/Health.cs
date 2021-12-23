using System;

public class Health 
{
    public int Value { get; protected set; }

    public event Action Death;

    private readonly int _maxValue;

    public int MaxValue => _maxValue;
    public event Action<int> ValueChanged; 

    public Health(int maxValue)
    {
        if (maxValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxValue));

        _maxValue = maxValue;
        Value = _maxValue;
        if (Value <= 0)
            throw new ArgumentOutOfRangeException(nameof(Value));
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        Value -= damage;

        if (Value <= 0)
        {
            Death?.Invoke();
            Value = 0;
        }

        ValueChanged?.Invoke(Value);
    }

    public void SetFull()
    {
        Value = _maxValue;
        ValueChanged?.Invoke(Value);
    }
}