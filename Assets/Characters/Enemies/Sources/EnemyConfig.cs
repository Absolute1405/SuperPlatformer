using UnityEngine;

public class EnemyConfig : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;

    public int Damage => _damage;
    public int MaxHealth => _maxHealth;
}
