using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AnimationsTest : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _leftTrigger = "MoveLeft";
    [SerializeField] private string _rightTrigger = "MoveRight";


    private void Start()
    {
        var behaviours = _animator.GetBehaviours<MoveAnimatorBehaviour>();

        foreach (var behaviour in behaviours)
        {
            behaviour.StateEnded += BehaviourOnStateEnded;
        }

        Animate();
        _animator.GetCurrentAnimatorStateInfo(0);
    }

    private void BehaviourOnStateEnded(string name)
    {
        Debug.Log(name);
    }

    private async void Animate()
    {
        await Task.Delay(2000);
        _animator.SetTrigger(_leftTrigger);
        await Task.Delay(2000);
        _animator.SetTrigger(_rightTrigger);
    }

    private async void OnClipStarted(float lenght)
    {
        var time = lenght * 1000;
        await Task.Delay((int) time);
    }
}
