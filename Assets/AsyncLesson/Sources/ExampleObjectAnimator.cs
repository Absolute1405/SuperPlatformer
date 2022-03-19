using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExampleObjectAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _rotateBool = "Rotate";

    public void Rotate(bool value)
    {
        _animator.SetBool(_rotateBool, value);
    }
}
