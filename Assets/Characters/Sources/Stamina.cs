using System;

public class Stamina 
{
    private readonly int _maxValue;
    
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
    }

    public bool Decrease(int x)
    {
        if (x < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(x));
        }

        bool canAct = Value - x > 0;

        if (!canAct)
        {
            return canAct;
        }

        Value -= x;

        return canAct;
    }
}
