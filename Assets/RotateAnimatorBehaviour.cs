using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RotateAnimatorBehaviour : StateMachineBehaviour
{
    public event Action StateEnded;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Internal");
        StateEnded?.Invoke();
    }
}
