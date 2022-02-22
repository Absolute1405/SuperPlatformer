using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constant Weapon", menuName = "Configs/Weapons/ConstantWeapon", order = 0)]
public class WeaponConstant : Weapon
{
    [SerializeField] private int _damage;

    public int Damage => _damage;

    public override Damage GetDamage()
    {
        return new Damage(_damage, DamageType);
    }
}
