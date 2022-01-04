using System.Collections;

public interface IAttack
{
    void Initialize();
    IEnumerator Attack(IDamageable target);
    IEnumerator Attack();
}
