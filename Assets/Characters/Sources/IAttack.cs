using System.Collections;

public interface IAttack
{
    void Initialize();
    IEnumerator Attack(IDamageable target, Damage damage);
    IEnumerator Attack(Damage damage);

    void UpdateDirection(Direction direction);
}
