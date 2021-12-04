using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private BoxCollider2D _rangeCollider;

    private float _delay;
    private Arrow _prefab;
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        ArcherConfig archerConfig = config as ArcherConfig;
        _delay = archerConfig.AttackDelay;
        _prefab = archerConfig.ArrowPrefab;
        _rangeCollider.size = Vector2.right * archerConfig.AttackRange;
        _rangeCollider.isTrigger = true;
    }
    protected override IEnumerator LifeCycle()
    {
        Attack.Attack();
        yield return new WaitForSeconds(_delay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IPlayer>(out var damageable))
        {
            StartCoroutine(nameof(LifeCycle));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out var damageable))
        {
            StopCoroutine(nameof(LifeCycle));
        }
    }
}
