using UnityEngine;
using System.Collections;
namespace AppleGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        [SerializeField] private float _speed;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void Move(float input)
        {
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x+_speed*input ,_rigidbody.velocity.y)
        }

    }
}

