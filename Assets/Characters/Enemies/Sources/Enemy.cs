using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected IAttack _attack;
    protected Health _health { get; private set; }

    public virtual void Initialize(EnemyConfig config)
    {
        _attack.Initialize(config.Damage);
        _health = new Health(config.MaxHealth);
    }

    protected abstract IEnumerator LifeCycle();

}
