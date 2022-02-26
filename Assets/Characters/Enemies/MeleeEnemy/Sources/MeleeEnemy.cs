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
        
        var banditConfig = config as MeleeEnemyConfig;
        _speed = banditConfig.MoveSpeed;
        Attack.AttackStarted += _animator.Attack;
        Attack.AttackEnded += OnAttackEnded;

        _maxX = transform.position.x + _rightBound;
        _minX = transform.position.x + _leftBound;
    }

    private void OnAttackEnded()
    {
        StartCoroutine(LifeCycle());
    }

    protected override void OnAbandoned()
    {
        _movement.Stop();
        StopAllCoroutines();
        _animator.Death();
    }

    protected override void OnHit(int value)
    {
        base.OnHit(value);
        _animator.Hurt();
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
        if (other.TryGetComponent<IPlayerDamageable>(out var target))
        {
            StopAllCoroutines();
            _movement.Stop();

            bool playerRight = other.gameObject.transform.position.x > transform.position.x;

            if (playerRight)
            {
                DirectionComponent.Set(Direction.Right);
            }
            else
            {
                DirectionComponent.Set(Direction.Left);
            }

            StartCoroutine(Attack.Attack());
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