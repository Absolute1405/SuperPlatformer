using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    private PlayerState _jumpState;
    private PlayerState _idleState;
    private PlayerState _attackState;

    private PlayerState _currentState;

    public PlayerStateMachine(PlayerAnimator animator)
    {
        _jumpState = new PlayerJumpState(animator);
        //_idleState = new PlayerIdleState(animator);
        //_attackState = new PlayerAttackState(animator);

        // all states init

        _jumpState.AddPossibleNextStates(_idleState, _attackState);
    }

    private void ChangeState(PlayerState state)
    {
        _currentState.OnStateExit();
        ;
        var possible = _currentState.PossibleNextStates.Contains(state);

        if (possible == false) return;

        _currentState = state;
        _currentState.OnStateEnter();
    }

    public void Jump()
    {
        
    }

    public void Attack()
    {

    }

    public void Move()
    {

    }
}
