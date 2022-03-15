using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerState
{
    public override void Jump(PlayerPhysics physics, bool grounded)
    {
        
    }

    public override bool NextStateAvailable(PlayerState state)
    {
        if (state is PlayerIdleState) return true;

        return false;
    }

    public override void OnStateEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit()
    {
        throw new System.NotImplementedException();
    }
}
