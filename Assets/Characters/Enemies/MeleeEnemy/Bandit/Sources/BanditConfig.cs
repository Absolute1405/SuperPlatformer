using UnityEngine;

[CreateAssetMenu(fileName = "New Bandit Config", menuName = "Configs/Enemies/Bandit", order = 2)]
public class BanditConfig : EnemyConfig
{
    [SerializeField] private float _moveRange;
    public float MoveRange => _moveRange;
}
