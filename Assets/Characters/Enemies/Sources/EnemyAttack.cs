using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action AttackStarted;
    public int Damage { get; private set; }

    public virtual void Attack(IDamageable target)
    {
        AttackStarted?.Invoke();
    }

    public virtual void Attack()
    {
        AttackStarted?.Invoke();
    }

    public virtual void Initialize(int damage)
    {
        Damage = damage;
    }
}
