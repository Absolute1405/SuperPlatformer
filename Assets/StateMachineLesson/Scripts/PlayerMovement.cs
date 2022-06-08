using System;
using UnityEngine;
using System.Collections;

namespace AppleGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public bool Moving => _rigidbody.velocity.x != 0;

        [SerializeField] private float _speed;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float input)
        {
            _rigidbody.velocity = new Vector2(_speed * input, _rigidbody.velocity.y);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity -= Vector2.right * 0.01f;
        }
    }
}

