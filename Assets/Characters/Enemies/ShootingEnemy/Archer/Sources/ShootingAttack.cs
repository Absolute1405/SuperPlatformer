using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : EnemyAttack
{
    [SerializeField] private Arrow _prefab;
    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        
    }
    public override void Attack(IDamageable target)
    {
        base.Attack(target);
        Instantiate(_prefab);
        _prefab.Initialaze();
    }
}
