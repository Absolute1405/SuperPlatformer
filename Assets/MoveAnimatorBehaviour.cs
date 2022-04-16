using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimatorBehaviour : StateMachineBehaviour
{
    [SerializeField] private string _name;
    public event Action<string> StateEnded;
    public event Action<float> StateEntered;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEntered?.Invoke(stateInfo.length);
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEnded?.Invoke(_name);
    }

}
