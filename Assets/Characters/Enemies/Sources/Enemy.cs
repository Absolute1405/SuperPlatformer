using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected EnemyAttack Attack { get; private set; }
    protected Health Health { get; private set; }
    protected CharacterDirection DirectionComponent { get; private set; }

    public virtual void Initialize(EnemyConfig config)
    {
        DirectionComponent = GetComponent<CharacterDirection>();
        if (DirectionComponent is null)
            throw new ArgumentNullException(nameof(DirectionComponent));

        Attack = GetComponent<EnemyAttack>();
        if (Attack is null)
            throw new ArgumentNullException(nameof(Attack));

        Attack.Initialize(config.Damage);
        Health = new Health(config.MaxHealth);
    }

    protected abstract IEnumerator LifeCycle();

}
