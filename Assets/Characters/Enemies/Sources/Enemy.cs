using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IAttack))]
public abstract class Enemy : MonoBehaviour
{
    protected EnemyAttack Attack { get; private set; }
    protected Health Health { get; private set; }

    public virtual void Initialize(EnemyConfig config)
    {
        Attack = GetComponent<EnemyAttack>();
        Attack.Initialize(config.Damage);
        Health = new Health(config.MaxHealth);
    }

    protected abstract IEnumerator LifeCycle();

}
