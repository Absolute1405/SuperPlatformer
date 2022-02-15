using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private DamageType _damageType;

    public Sprite Icon => _icon;
    public DamageType DamageType => _damageType;

    public abstract Damage GetDamage();
}
