using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemyState
{
    public List<MeleeEnemyState> PossibleNextStates { get; private set; }
    protected EnemyAnimator animator { get; private set; }

    protected MeleeEnemyState(EnemyAnimator animator)
    {
        PossibleNextStates = new List<MeleeEnemyState>();
        this.animator = animator;
    }

    public abstract void OnMelleEnemyStateEnter();
    public abstract void OnMelleEnemyStateExit();

    public void AddPossibleNextStates(params MeleeEnemyState[] states)
    {
        PossibleNextStates.AddRange(states);
    }
}
