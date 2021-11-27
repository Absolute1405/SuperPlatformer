using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Components")]
    [SerializeField] private Movement _movement;
    [SerializeField] private MeleeEnemyAnimator _animator;

    [Header("Settings")]
    [SerializeField] private float _leftBound = -1f;
    [SerializeField] private float _rightBound = 1f;

    private float _minX;
    private float _maxX;
    private float _speed;

    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        
        MeleeEnemyConfig banditConfig = config as MeleeEnemyConfig;
        _speed = banditConfig.MoveSpeed;
        Attack.AttackStarted += _animator.Attack;

        _maxX = transform.position.x + _rightBound;
        _minX = transform.position.x + _leftBound;
    }

    private void Start()
    {
        StartCoroutine(LifeCycle());
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            bool moveRight = DirectionComponent.Value == Direction.Right;
            _animator.SetFlip(moveRight);
            _movement.Move(DirectionComponent.Value, _speed);

            if (moveRight)
            {
                yield return new WaitUntil(() => transform.position.x > _maxX);
            }
            else
            {
                yield return new WaitUntil(() => transform.position.x < _minX);
            }

            DirectionComponent.Set(DirectionGetter.GetReversed(DirectionComponent.Value));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var target))
        {
            Attack.Attack(target);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        var left = new Vector3(transform.position.x + _rightBound, transform.position.y);
        var right = new Vector3(transform.position.x + _leftBound, transform.position.y);

        Gizmos.DrawLine(left, right);
    }
}