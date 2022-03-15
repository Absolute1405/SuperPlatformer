using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    private PlayerState _currentState;

    private PlayerAnimator _animator;
    private PlayerPhysics _physics;
    private CharacterAttack _attack;

    public PlayerStateMachine(PlayerAnimator animator, PlayerPhysics physics, CharacterAttack attack)
    {
        _animator = animator;
        _physics = physics;
        _attack = attack;
    }

    private void ChangeState(PlayerState state)
    {
        var possible = _currentState.NextStateAvailable(state);
        if (possible == false) return;

        _currentState.OnStateExit();
        _currentState = state;
        _currentState.OnStateEnter();
    }

    public void Jump(bool grounded)
    {
        _currentState.Jump(_physics, grounded);
        _animator.SetGrounded(grounded);
        ChangeState(new PlayerOnAirState());
    }

    public void Attack()
    {
        _animator.Attack();
        _currentState.Attack(_attack);
    }

    public void Move(float input)
    {
        _animator.Move(Mathf.Approximately(input, 0) == false);
        _currentState.Move(_physics, input);
    }

    public void Cast()
    {
        ChangeState(new PlayerCastState());
    }

    public void Reset()
    {
        _animator.Move(false);
        _animator.SetGrounded(true);
        ChangeState(new PlayerIdleState());
    }
}
