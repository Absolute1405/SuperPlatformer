using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    [SerializeField] private DamageType _damageType = DamageType.Physical;
    public Damage Damage { get; protected set; }

    public virtual void Initialize()
    {
        Damage = new Damage(_damageValue, _damageType);
    }

    protected virtual void Hit(IDamageable target)
    {
        target.TakeDamage(Damage);
    }
}
