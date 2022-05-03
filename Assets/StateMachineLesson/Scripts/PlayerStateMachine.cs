using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AppleGame
{
    public class PlayerStateMachine
    {
        private PlayerState _currentState;
        private readonly PlayerOnAirState _onAir;
        private readonly PlayerIdleState _idle;
        private readonly PlayerRunState _run;
        public PlayerStateMachine()
        {
            _onAir = new PlayerOnAirState();
            _idle = new PlayerIdleState();
            _run = new PlayerRunState();
            _currentState = _onAir;
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
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();

        }
        public void SetOnAir()
        {
            SetState(_onAir);
        }
        public void SetRun()
        {
            SetState(_run);
        }
        public void SetIdle()
        {
            SetState(_idle);
        }
    }
}

