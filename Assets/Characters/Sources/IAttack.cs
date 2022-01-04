using System.Collections;

public interface IAttack
{
    void Initialize();
    IEnumerator Attack(IDamageable target,int damage);
    IEnumerator Attack(int damage);

}
