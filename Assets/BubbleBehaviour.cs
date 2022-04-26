using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : StateMachineBehaviour
{
    public event Action ExitState;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExitState?.Invoke();
    }
}
