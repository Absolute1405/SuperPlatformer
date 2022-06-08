﻿using UnityEngine;
using UnityEditor;
namespace AppleGame
{
    public class PlayerIdleState : PlayerState
    {
        private PlayerJump _jump;
        
        public PlayerIdleState(PlayerJump jump, PlayerAnimatinor playerAnimatinor)
        {
            _jump = jump;
        }
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Jump()
        {
            _jump.Jump();
        }

        public override void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}