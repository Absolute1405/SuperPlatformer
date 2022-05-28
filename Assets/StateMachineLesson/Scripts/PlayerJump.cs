using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AppleGame
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _gravityForce = -9.81f;
        [SerializeField] private float _gravityScale = 5f;

        public float _velocity = 0;

        private Rigidbody2D _rigidbody;
        public event Action<bool> OnAir;
        private bool _onAir;
        

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
        }

        private void Update()
        {
            var pos = transform.position;
            var y = pos.y;
            var destination = y + _velocity * Time.deltaTime / 2;
            transform.position = new Vector3(pos.x, destination);

            if (_velocity > _gravityForce && _onAir)
            {
                _velocity -= Time.deltaTime * _gravityScale;
            }
        }
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<BoxCollider2D>())
            {
                OnAir?.Invoke(false);
                _velocity = 0;
                _onAir = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
            OnAir?.Invoke(true);
            _onAir = true;
            
            
        }
        

        public void Jump()
        {
            var force = Vector2.up * _jumpForce;
            //_rigidbody.AddForce(force, ForceMode2D.Impulse);
            if (!_onAir)
            {
                _velocity += _jumpForce;
            }
            
        }
    }
}

