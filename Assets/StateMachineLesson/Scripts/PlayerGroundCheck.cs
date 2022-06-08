using System;
using UnityEngine;

namespace AppleGame
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerGroundCheck : MonoBehaviour
    {
        [SerializeField] private int _groundLayer = 8;

        public event Action<bool> AirChanged;
        public bool OnAir { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnGroundTouch(other, true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnGroundTouch(other, false);
        }

        protected virtual void OnGroundTouch(Collider2D other, bool value)
        {
            if (_groundLayer != other.gameObject.layer)
                return;

            AirChanged?.Invoke(!value);
            OnAir = value;
        }
    }
}

