using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class PlayerSoftGroundCheck : PlayerGroundCheck
    {
        public event Action<bool> SoftGround;
        
        protected override void OnGroundTouch(Collider2D other, bool value)
        {
            base.OnGroundTouch(other, value);

            var soft = other.gameObject.CompareTag("Soft");
            SoftGround?.Invoke(soft);
        }
    }
}

