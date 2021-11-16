using System;

public interface IAttack
{
    event Action AttackStarted; 
    void Initialize(int damage);
    void Attack(IDamageable target);
}
