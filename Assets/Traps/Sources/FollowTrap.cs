using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrap : Trap, IFollowTrap
{
    public float Time { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public IEnumerator FollowFor(Health target)
    {
        throw new System.NotImplementedException();
    }

    public override void Hit(IDamageable target)
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }
}
