using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 10f;
        private Rigidbody2D _rigidbody;
        public event Action<bool> OnAir;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnAir?.Invoke(false);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {

            OnAir?.Invoke(true);
        }

        public void Jump()
        {
            
            var force = Vector2.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
            
        }

    }
}

