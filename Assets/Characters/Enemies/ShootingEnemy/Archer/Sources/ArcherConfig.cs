using UnityEngine;

[CreateAssetMenu(fileName = "New Archer Config", menuName = "Configs/Enemies/Archer", order = 1)]
public class ArcherConfig : EnemyConfig
{
    [SerializeField] private float _attackRange; // What for?
    [SerializeField] private float _attackDelay;
    [SerializeField] private Arrow _arrowPrefab;
    public float AttackRange => _attackRange;
    public float AttackDelay => _attackDelay;
    public Arrow ArrowPrefab => _arrowPrefab;
}
