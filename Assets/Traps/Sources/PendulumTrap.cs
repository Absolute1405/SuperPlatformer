using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumTrap : Trap,IDamageable
{
    
    public override void Initialize()
    {
        Debug.Log("Ok");
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Ok");
        throw new System.NotImplementedException();
    }
}