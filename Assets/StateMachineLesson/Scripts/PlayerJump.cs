using UnityEngine;

namespace AppleGame
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _onAir;
        
        public void Jump()
        {
            if (_onAir) return;

            var force = Vector2.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        public void Jump(float jumpForce)
        {
            if (_onAir) return;

            var force = Vector2.up * jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        public void ChangeAirState(bool value)
        {
            _onAir = value;
        }
    }
}

