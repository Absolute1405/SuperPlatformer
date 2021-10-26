public interface IAttack
{
    void Initialize(int damage);
    void Attack(IDamageable target);
}
