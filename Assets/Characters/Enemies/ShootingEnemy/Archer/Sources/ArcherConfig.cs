using UnityEngine;

[CreateAssetMenu(fileName = "New Archer Config", menuName = "Configs/Enemies/Archer", order = 1)]
public class ArcherConfig : EnemyConfig
{
    [SerializeField] private float _attackRange; 
    [SerializeField] private float _attackDelay;
    public float AttackRange => _attackRange;
    public float AttackDelay => _attackDelay;
}
