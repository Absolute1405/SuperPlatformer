using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTouchTrap : Trap
{
    [SerializeField] private TrapTouchCollider _collision;

    public override void Initialize()
    {
        base.Initialize();
        _collision.TargetTouched += Hit;
    }

    private void OnDestroy()
    {
        _collision.TargetTouched -= Hit;
    }
}