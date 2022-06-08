namespace AppleGame
{
    public class PlayerRunState : PlayerState
    {
        private PlayerJump _jump;
        public PlayerRunState (PlayerJump Jump )
        {
            _jump = Jump;
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
