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
        yield return _attack.Attack(target,Damage);
        AttackEnded?.Invoke();
    }

    public IEnumerator Attack()
    {
        AttackStarted?.Invoke();
        yield return _attack.Attack(Damage);
        AttackEnded?.Invoke();
    }

    public void Initialize(int damage)
    {
        _attack = GetComponent<IAttack>();
        Damage = damage;
        _attack.Initialize();
        
    }

    public void UpdateDirection(Direction direction)
    {
        _attack.UpdateDirection(direction);
    }
}
