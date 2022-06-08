using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatinor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string onJump;
    [SerializeField] private string onIdle;
    [SerializeField] private string onRun;
    private void Awake()
    {
        animator.SetBool(onIdle, true);
        animator.SetBool(onRun, false);
        animator.SetBool(onJump, false);
    }
    public void SetJump()
    {
        animator.SetBool(onIdle, false);
        animator.SetBool(onRun, false);
        animator.SetBool(onJump, true);
    }
    public void SetRun()
    {
        animator.SetBool(onIdle, false);
        animator.SetBool(onRun, true);
        animator.SetBool(onJump, false);
    }
    public void SetIdle()
    {
        animator.SetBool(onIdle, true);
        animator.SetBool(onRun, false);
        animator.SetBool(onJump, false);
    }
}
