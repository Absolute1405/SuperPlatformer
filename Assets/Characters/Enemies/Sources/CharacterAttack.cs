using System;
using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public event Action AttackStarted;
    public event Action AttackEnded;
    private IAttack _attack;

    public int Damage { get; private set; }

    public IEnumerator Attack(IDamageable target)
    {
        AttackStarted?.Invoke();
        yield return _attack.Attack(target);
        AttackEnded?.Invoke();
    }

    public IEnumerator Attack()
    {
        AttackStarted?.Invoke();
        yield return _attack.Attack();
        AttackEnded?.Invoke();
    }

    public void Initialize(int damage)
    {
        Damage = damage;
        _attack.Initialize();
    }
}
