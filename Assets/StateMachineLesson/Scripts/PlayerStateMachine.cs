using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class PlayerStateMachine
    {
        private PlayerState _currentState;
        private PlayerAnimatinor _playerAnimatinor;
        private readonly PlayerOnAirState _onAir;
        private readonly PlayerIdleState _idle;
        private readonly PlayerRunState _run;
        public PlayerStateMachine(PlayerJump jump, PlayerAnimatinor playerAnimatinor)
        {
            _onAir = new PlayerOnAirState();
            _idle = new PlayerIdleState(jump);
            _run = new PlayerRunState(jump);
            _currentState = _onAir;
            _playerAnimatinor = playerAnimatinor;
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
            _playerAnimatinor.SetJump();
        }

        public void SetRun()
        {
            SetState(_run);
            _playerAnimatinor.SetRun();
        }
        
        public void SetIdle()
        {
            SetState(_idle);
            _playerAnimatinor.SetIdle();
        }
        
    }
}

