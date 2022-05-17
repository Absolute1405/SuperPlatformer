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

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            var force = Vector2.up * _jumpForce;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}

