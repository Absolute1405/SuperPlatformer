using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : EnemyAttack
{
    [SerializeField] private Arrow _prefab;
    [SerializeField] private Collider2D _enemyCollider;

    private ICharacterDirection _direction;
    private float _spawnOffset;

    public override void Initialize(int damage)
    {
        base.Initialize(damage);
        
        _direction = GetComponent<ICharacterDirection>();

        if (_direction.Value == Direction.None)
            throw new ArgumentException("None direction");

        _enemyCollider = GetComponent<Collider2D>();

        if (_enemyCollider is null)
            throw new ArgumentNullException();

        _spawnOffset = _enemyCollider.bounds.size.x / 2;
    }


    public override void Attack()
    {
        base.Attack();
        Vector2 arrowPosition = transform.position;
        arrowPosition += DirectionGetter.GetVectorFromDirection(_direction.Value) * _spawnOffset;
        var arrow = Instantiate(_prefab, arrowPosition, Quaternion.identity, transform);
        arrow.Initialize(_direction.Value);
    }
}
