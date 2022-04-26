using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class AppleRottenState : AppleState
    {
        public override void OnHit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateEnter()
        {
            Debug.Log("Rotten");
        }

        public override void OnStateExit()
        {
            Debug.Log("Stopped to rot");
        }

        public override void OnTouch(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}


