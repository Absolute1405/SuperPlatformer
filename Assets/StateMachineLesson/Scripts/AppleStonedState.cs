using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class AppleStonedState : AppleState
    {
        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateEnter()
        {
            Debug.Log("Stoned");
        }

        public override void OnStateExit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnTouch(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}

