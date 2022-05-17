using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class AppleStateMachine
    {
        private readonly AppleFallState _fallState;
        private readonly AppleGroundedState _groundedState;
        private readonly AppleRottenState _rottenState;
        private readonly AppleStonedState _stonedState;

        private AppleState _currentState;

        public AppleStateMachine()
        {
            _fallState = new AppleFallState();
            _groundedState = new AppleGroundedState();
            _rottenState = new AppleRottenState();
            _stonedState = new AppleStonedState();

            _currentState = _fallState;
        }

        public void Touch(Player player)
        {
            _currentState.OnTouch(player);
        }

        public void Hit()
        {
            _currentState.OnHit();
        }

        public void SetFallState()
        {
            SetState(_fallState);
        }

        public void SetGroundedState()
        {
            SetState(_groundedState);
        }

        public void SetRottenState()
        {
            SetState(_rottenState);
        }

        public void SetStonedState()
        {
            SetState(_stonedState);
        }

        private void SetState(AppleState state)
        {
            _currentState?.OnStateExit();
            _currentState = state;
            _currentState.OnStateEnter();
        }
    }
}

