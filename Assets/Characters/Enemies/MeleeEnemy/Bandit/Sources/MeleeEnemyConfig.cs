using UnityEngine;

[CreateAssetMenu(fileName = "New Bandit Config", menuName = "Configs/Enemies/Bandit", order = 2)]
public class MeleeEnemyConfig : EnemyConfig
{
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
}
