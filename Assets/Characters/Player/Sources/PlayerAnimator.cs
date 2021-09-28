using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private string _attackTrigger = "Attack";
    [SerializeField] private string _hurtTrigger = "Hurt";
    [SerializeField] private string _deathTrigger = "Death";
    [SerializeField] private string _moveBool = "Move";
    [SerializeField] private string _groundBool = "Grounded";

    public void Attack()
    {
        _animator.SetTrigger(_attackTrigger);
    }

    public void Hurt()
    {
        _animator.SetTrigger(_hurtTrigger);
    }

    public void Death()
    {
        _animator.SetTrigger(_deathTrigger);
    }

    public void Move(bool value)
    {
        _animator.SetBool(_moveBool, value);
    }

    public void SetGrounded(bool value)
    {
        _animator.SetBool(_groundBool, value);
    }

    public void SetFlip(bool value)
    {
        _renderer.flipX = value;
    }
}