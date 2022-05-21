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
        [SerializeField] private float _maxJump = 15f;
        [SerializeField] private const float _G= 9.81f;
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

        public async void Jump()
        {
            
            var force = Vector2.up * _jumpForce;
            //_rigidbody.AddForce(force, ForceMode2D.Impulse);
            var maxJumpValiu = _maxJump + transform.position.y;
            var startpositionY = transform.position.y;
            for (float positionY = transform.position.y; positionY<maxJumpValiu; positionY = transform.position.y)
            {
                transform.Translate(new Vector2(0,_jumpForce*Time.deltaTime));
                await Task.Yield();
            }
            for (float positionY = transform.position.y; positionY > startpositionY; positionY = transform.position.y)
            {
                transform.Translate(new Vector2(0,  -(_G* Time.deltaTime)));
                await Task.Yield();
            }

        }

    }
}

