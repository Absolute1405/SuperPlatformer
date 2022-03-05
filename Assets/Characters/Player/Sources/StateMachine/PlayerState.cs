using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public List<PlayerState> PossibleNextStates { get; private set; }
    protected PlayerAnimator animator { get; private set; }

    protected PlayerState(PlayerAnimator animator)
    {
        PossibleNextStates = new List<PlayerState>();
        this.animator = animator;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();

    public void AddPossibleNextStates(params PlayerState[] states)
    {
        PossibleNextStates.AddRange(states);
    }
}
