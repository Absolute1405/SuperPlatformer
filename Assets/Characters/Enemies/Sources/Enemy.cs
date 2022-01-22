using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField]private StatBar _statBar;

    protected CharacterAttack Attack { get; private set; }
    protected Health Health { get; private set; }
    protected CharacterDirection DirectionComponent { get; private set; }
    

    public virtual void Initialize(EnemyConfig config)
    {
        DirectionComponent = GetComponent<CharacterDirection>();
        if (DirectionComponent is null)
            throw new ArgumentNullException(nameof(DirectionComponent));

        Attack = GetComponent<CharacterAttack>();
        if (Attack is null)
            throw new ArgumentNullException(nameof(Attack));

        Attack.Initialize(config.Damage);
        Health = new Health(config.MaxHealth);
        
        if (_statBar is null) return;

        _statBar.Initialize(Health.MaxValue);
        Health.ValueChanged += _statBar.RefreshBar;
        Health.SetFull();
        Health.Death += OnDeath;
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);
    }

    protected abstract IEnumerator LifeCycle();

    protected abstract void OnDeath();

}
