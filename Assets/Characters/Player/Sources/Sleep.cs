using System;

public class Sleep 
{
    private const int _decrease= 1;

    private int _maxValue;
    public int Value { get; protected set; }
    public event Action<int> ValueChanged;

    public Sleep(int maxSleep)
    {
        _maxValue = maxSleep;
        Value = _maxValue;
    }
    public void SetFull()
    {
        Value = _maxValue;
    }
    public bool Decrease()
    {
        bool canDecrease=false;
        if (Value <= 0)
        {
            canDecrease = false;
        }
        if (Value >= _decrease)
        {
            canDecrease = true;
            Value -= _decrease;
        }
        return canDecrease;
    }
}
