using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public const int DefaultDamage = 5;
    public int Damage { get; protected set; }

    public virtual void Initialize()
    {
        Damage = DefaultDamage;
    }

    protected virtual void Hit(IDamageable target)
    {
        target.TakeDamage(Damage);
    }

    
}
