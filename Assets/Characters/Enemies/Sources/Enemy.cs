using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField]private StatBar _statBar;

    protected CharacterAttack Attack { get; private set; }
    protected Stat Health { get; private set; }
    protected CharacterDirection DirectionComponent { get; private set; }
    protected EnemyStatService Stats;
    
    public virtual void Initialize(EnemyConfig config)
    {
        Health = new Stat(config.MaxHealth);
        Stats = new EnemyStatService(Health);

        DirectionComponent = GetComponent<CharacterDirection>();
        if (DirectionComponent is null)
            throw new ArgumentNullException(nameof(DirectionComponent));

        Attack = GetComponent<CharacterAttack>();
        if (Attack is null)
            throw new ArgumentNullException(nameof(Attack));

        Attack.Initialize(config.Weapon);
        
        if (_statBar is null) return;

        _statBar.Initialize(Health.MaxValue);
        Stats.HealthChanged += OnHit;
        Health.SetFull(); //TODO
        Health.Abandoned += OnAbandoned;
    }

    public void TakeDamage(Damage damage)
    {
        Stats.TakeDamage(damage);
    }

    protected abstract IEnumerator LifeCycle();

    protected virtual void OnAbandoned()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnHit(int value)
    {
        _statBar.RefreshBar(value);
    }

    public void Dispose()
    {
        Health.ValueChanged -= OnHit;
        Health.Abandoned -= OnAbandoned;
    }
}
