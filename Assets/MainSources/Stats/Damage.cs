public class Damage
{
    public DamageType Type { get; }
    public int Value { get; }

    public Damage(int value, DamageType type)
    {
        Value = value;
        Type = type;
    }
}

public enum DamageType
{
    None, Physical, Light, 
    Dark, Fire, Water, Wind, Earth
}
