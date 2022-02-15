using System;
using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public event Action AttackStarted;
    public event Action AttackEnded;
    private IAttack _attack;

    public Weapon Weapon { get; private set; }

    public IEnumerator Attack(IDamageable target)
    {
        AttackStarted?.Invoke();
        var damage = Weapon.GetDamage();
        yield return _attack.Attack(target, damage);
        AttackEnded?.Invoke();
    }

    public IEnumerator Attack()
    {
        AttackStarted?.Invoke();
        var damage = Weapon.GetDamage();
        yield return _attack.Attack(damage);
        AttackEnded?.Invoke();
    }

    public void Initialize(Weapon weapon)
    {
        _attack = GetComponent<IAttack>();
        Weapon = weapon;
        _attack.Initialize();
    }

    public void UpdateDirection(Direction direction)
    {
        _attack.UpdateDirection(direction);
    }
}
