using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class Player : MonoBehaviour
    {
        private PlayerStateMachine _stateMachine;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerJump _jump;
        [SerializeField] private PlayerGroundCheck _groundCheck;
        [SerializeField] private PlayerAnimator playerAnimator;

        public event Action<bool> isPositivelyValie;

        private void Awake()
        {
            _stateMachine = new PlayerStateMachine(_jump,playerAnimator);
            _groundCheck.AirChanged += _jump.ChangeAirState;
        }

        private void Start()
        {
            _stateMachine.SetIdle();
        }

        private void Update()
        {
            #region IfTest
            _movement.Move(Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _stateMachine.Jump();

            }
            #endregion

            if (_groundCheck.OnAir)
            {
                _stateMachine.SetOnAir();
            }
            else if (_movement.Moving)
            {
                _stateMachine.SetRun();
            }
            else
            {
                _stateMachine.SetIdle();
            }
        }
        public void UpdteScore(bool positively)
        {
            
        }
    }
    
}


