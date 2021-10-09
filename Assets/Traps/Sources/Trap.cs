using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public int Damage { get; protected set; }

    public abstract void Initialize();

    protected virtual void Hit(IDamageable target)
    {
        target.TakeDamage(Damage);
    }
}
