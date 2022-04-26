using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbul_Behaviour : StateMachineBehaviour
{
    public event Action<bool> ExitState;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ExitState?.Invoke(true);
    }
}
