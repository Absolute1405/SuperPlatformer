using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public abstract class AppleState
    {
        public abstract void OnStateEnter();
        public abstract void OnStateExit();

        public abstract void OnTouch(Player player);
        public abstract void OnHit();
    }
}

