using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "New Random Weapon", menuName = "Configs/Weapons/RandomWeapon", order = 1)]
public class WeaponRandom : Weapon
{
    [SerializeField, Min(0)] private int _minDamage;
    [SerializeField, Min(1)] private int _maxDamage;

    private void OnValidate()
    {
        if (_minDamage >= _maxDamage)
        {
            Debug.LogError("Wrong damage values");

            _maxDamage = ++_minDamage;
        }
    }

    public override Damage GetDamage()
    {
        var damage = Random.Range(_minDamage, _maxDamage);
        return new Damage(damage, DamageType);
    }
}
