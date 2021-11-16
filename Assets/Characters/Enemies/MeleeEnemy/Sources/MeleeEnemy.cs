using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private Movement _movement;
    [SerializeField] private MeleeEnemyAnimator _animator;
    [SerializeField] private Direction _startDirection = Direction.Right;

    private float _maxX;
    private float _minX;
    private float _speed;
    private Direction _direction;

    private bool OutOfBounds => transform.position.x > _maxX || transform.position.x < _minX;

    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        
        MeleeEnemyConfig banditConfig = config as MeleeEnemyConfig;
        float range = banditConfig.MoveRange;
        _speed = banditConfig.MoveSpeed;

        _maxX = transform.position.x + range;
        _minX = transform.position.x - range;

        _direction = _startDirection;
        Attack.AttackStarted += _animator.Attack;
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            _animator.SetFlip(_direction == Direction.Right);
            _movement.Move(_direction, _speed);
            yield return new WaitUntil(() => OutOfBounds);
            _direction = DirectionGetter.GetReversed(_direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var target))
        {
            Attack.Attack(target);
        }
    }
}