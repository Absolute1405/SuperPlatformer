using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField, Min(0)] private int _damage;

    public int Damage => _damage;

    public abstract void Initialize();

    public abstract void Hit(Health target);
}
