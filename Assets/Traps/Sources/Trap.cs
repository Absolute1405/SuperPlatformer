using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public const int DefaultDamage = 5;
    public Damage Damage { get; protected set; }

    public virtual void Initialize()
    {
       
    }

    protected virtual void Hit(IDamageable target)
    {
        target.TakeDamage(Damage);
    }

    
}
