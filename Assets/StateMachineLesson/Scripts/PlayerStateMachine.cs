using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class PlayerStateMachine
    {
        private PlayerState _currentState;
        private PlayerAnimator _playerAnimator;
        private readonly PlayerOnAirState _onAir;
        private readonly PlayerIdleState _idle;
        private readonly PlayerRunState _run;

        public PlayerStateMachine(PlayerJump jump, PlayerAnimator playerAnimator)
        {
            _onAir = new PlayerOnAirState();
            _idle = new PlayerIdleState(jump);
            _run = new PlayerRunState(jump);
            _currentState = _onAir;
            _playerAnimator = playerAnimator;
        }

        public void Jump()
        {
            _currentState.Jump();
        }
        public void Attack()
        {
            _currentState.Attack();
        }
        private void SetState(PlayerState state)
        {
            if(_currentState== state)
            {
                return;
            }
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();

        }

        public void SetOnAir()
        {
            SetState(_onAir);
            _playerAnimator.SetJump();
        }

        public void SetRun()
        {
            SetState(_run);
            _playerAnimator.SetRun();
        }
        
        public void SetIdle()
        {
            SetState(_idle);
            _playerAnimator.SetIdle();
        }
        
    }
}

