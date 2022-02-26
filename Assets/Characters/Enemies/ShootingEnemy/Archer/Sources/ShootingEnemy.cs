using System.Collections;
using System;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private BoxCollider2D _rangeCollider;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _delayAnimation;
    public float PassArgument { get; private set; }
    private float _delay;
    
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        PassArgument = _rangeCollider.size.x;
        ArcherConfig archerConfig = config as ArcherConfig;
        _delay = archerConfig.AttackDelay;
        
    }

    protected override void OnHit(int value)
    {
        base.OnHit(value);
        _animator.Hurt();
    }

    protected override void OnAbandoned()
    {
        base.OnAbandoned();
        StopAllCoroutines();
        _animator.Death();
        Destroy(gameObject);
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            _animator.Attack();
            yield return new WaitForSeconds(_delayAnimation);
            yield return Attack.Attack();
            yield return new WaitForSeconds(_delay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IPlayerDamageable>(out var damageable))
        {
            StartCoroutine(nameof(LifeCycle));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IPlayerDamageable>(out var damageable))
        {
            StopCoroutine(nameof(LifeCycle));
        }
    }
}
