using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : EnemyAttack
{
    [SerializeField] private Arrow _prefab;
    private ICharacterDirection _direction;
    private ShootingEnemy _Archer;
    private float _SizeBoxCollider2D;

    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        
        _direction = GetComponent<ICharacterDirection>();
    }


    public override void Attack(IDamageable target)
    {
        base.Attack(target);
        _SizeBoxCollider2D = _Archer.PassArgument;
        var arrow = Instantiate(_prefab);
        arrow.transform.position +=  (Vector3)DirectionGetter.GetVectorFromDirection(_direction.Value) * 3f;
        arrow.transform.position +=new Vector3(_SizeBoxCollider2D,0,0);
        _prefab.Initialaze(_direction.Value);
    }
}
