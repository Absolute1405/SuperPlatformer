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
    None, Physical, Stab,
    Light, Darkness, Fire,
    Water, Wind, Earth,
    Lightning, Void
}
