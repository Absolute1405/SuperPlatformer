using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastState : PlayerState
{
    public override void Jump(PlayerPhysics physics, bool grounded)
    {
        
    }

    public override void Attack(CharacterAttack attack)
    {
        
    }

    public override void Move(PlayerPhysics physics, float value)
    {
        
    }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }

    public override bool NextStateAvailable(PlayerState state)
    {
        if (state is PlayerIdleState) return true;

        return false;
    }
}
