using UnityEngine;
using UnityEditor;
namespace AppleGame
{
    public class PlayerIdleState : PlayerState
    {
        private PlayerJump _jump;
        
        
        public PlayerIdleState(PlayerJump jump)
        {
            _jump = jump;
            
        }
        public override void Attack()
        {
            
        }

        public override void Jump()
        {
            _jump.Jump();
        }

        public override void OnEnter()
        {
            
        }

        public override void OnExit()
        {
            
        }
    }
}