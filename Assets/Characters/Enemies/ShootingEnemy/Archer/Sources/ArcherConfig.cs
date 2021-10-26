using UnityEngine;

[CreateAssetMenu(fileName = "New Archer Config", menuName = "Configs/Enemies/Archer", order = 1)]
public class ArcherConfig : EnemyConfig
{
    [SerializeField] private float _attackRange;
    public float AttackRange => _attackRange;
}
