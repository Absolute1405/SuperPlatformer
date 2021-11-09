using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected IAttack Attack;
    protected Health Health { get; private set; }

    public virtual void Initialize(EnemyConfig config)
    {
        Attack.Initialize(config.Damage);
        Health = new Health(config.MaxHealth);
    }

    protected abstract IEnumerator LifeCycle();

}
