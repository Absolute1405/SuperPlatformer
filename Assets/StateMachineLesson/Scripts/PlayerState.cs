using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AppleGame
{
    public abstract class PlayerState
    {
        public abstract void Jump();

        public abstract void Attack();

        public abstract void OnEnter();

        public abstract void OnExit();

    }
}
 