using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _jumpForce;

        private Transform _transform;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody2D>();
            
        }
        private void Update()
        {
            if (Input.GetButtonDown("Space"))
            {
                Jamping();
            }
        }
        private void Jamping()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

    }
}


