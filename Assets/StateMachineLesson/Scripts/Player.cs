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

        private void Awake()
        {
            _stateMachine = new PlayerStateMachine(_jump);
            _groundCheck.OnAir += OnGroud;

        }

        private void Update()
        {
            _movement.Move(Input.GetAxis("Horizontal"));
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _stateMachine.Jump();
                
            }

        }
        private void OnGroud(bool onAir)
        {
            if (!onAir)
            {
                _stateMachine.SetIdle();
            }
            else
            {
                _stateMachine.SetOnAir();
            }
            
        }
    }
    
}


