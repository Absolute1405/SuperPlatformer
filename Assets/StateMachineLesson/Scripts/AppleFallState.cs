using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class AppleFallState : AppleState
    {
        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateEnter()
        {
            Debug.Log("Start fall");
        }

        public override void OnStateExit()
        {
            Debug.Log("Stop fall");
        }

        public override void OnTouch(Player player)
        {
            
        }

    }
}

