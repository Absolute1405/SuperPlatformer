using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void OnStateEnter();
    public abstract void OnStateExit();

    public virtual void Jump(PlayerPhysics physics, bool grounded)
    {
        if (grounded) physics.Jump();
    }

    public virtual void Move(PlayerPhysics physics, float value)
    {
        physics.Move(value);
    }

    public virtual void Attack(CharacterAttack attack)
    {
        attack.StartCoroutine(attack.Attack());
    }

    public abstract bool NextStateAvailable(PlayerState state);
}
