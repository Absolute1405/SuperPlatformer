using System;
using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private Movement _movement;

    private Direction _direction;
    private float _speed;
    private float _moveRange;
    //Wait for seconds ==> move range system
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        MeleeEnemyConfig meleeEnemyConfig = config as MeleeEnemyConfig;
        _moveRange = meleeEnemyConfig.MoveRange;
        _speed = meleeEnemyConfig.MoveSpeed;
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            _direction = Direction.Right;
            _movement.Move(_direction, _speed);
            yield return new WaitForSeconds(1f);
            _direction = Direction.Left;
            _movement.Move(_direction, _speed);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var player))
        {
            Attack.Attack(player);
        }
    }
}