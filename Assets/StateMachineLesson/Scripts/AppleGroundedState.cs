using UnityEngine;

namespace AppleGame
{
    public class AppleGroundedState : AppleState
    {
        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateEnter()
        {
            Debug.Log("Grounded");
        }

        public override void OnStateExit()
        {
            Debug.Log("Started to rot");
        }

        public override void OnTouch(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}

