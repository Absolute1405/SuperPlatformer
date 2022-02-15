using UnityEngine;

public class EnemyConfig : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Weapon _weapon;

    public Weapon Weapon => _weapon;
    public int MaxHealth => _maxHealth;
}
