using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : EnemyAttack
{
    [SerializeField] private Arrow _prefab;
    private ICharacterDirection _direction;

    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        _direction = GetComponent<ICharacterDirection>();
    }

    public override void Attack(IDamageable target)
    {
        base.Attack(target);
        var arrow = Instantiate(_prefab);
        arrow.transform.position += (Vector3) DirectionGetter.GetVectorFromDirection(_direction.Value) * 3f;
        _prefab.Initialaze(_direction.Value);
    }
}
