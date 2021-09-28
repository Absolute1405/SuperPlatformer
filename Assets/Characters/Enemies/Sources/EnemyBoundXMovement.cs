using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Characters.Enemy
{
    public class EnemyBoundXMovement : MonoBehaviour
    {
        public UnityEvent Flip;

        [SerializeField] private float _moveRange = 5f;
        [SerializeField] private float _speed = 3f;

        private Rigidbody2D _rigidbody;
        private float _startX;
        private Vector2 _savedVelocity;

        private bool OutOfRightBound => transform.position.x > _startX + _moveRange;
        private bool OutOfLeftBound => transform.position.x < _startX - _moveRange;

        public void Init(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
            _startX = transform.position.x;
            StartCoroutine(MoveX());
        }

        private IEnumerator MoveX()
        {
            while(true)
            {
                _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
                yield return new WaitUntil(() => OutOfRightBound);
                Flip?.Invoke();
                _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
                yield return new WaitUntil(() => OutOfLeftBound);
                Flip?.Invoke();
            }
        }

        public void PauseMovement()
        {
            _savedVelocity = _rigidbody.velocity;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        public void ResumeMovement()
        {
            _rigidbody.velocity = _savedVelocity;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void PauseMovementForTime(float time)
        {
            StartCoroutine(PauseForTime(time));
        }

        private IEnumerator PauseForTime(float time)
        {
            PauseMovement();

            for (float i = 0; i < time; i += Time.deltaTime)
            {
                yield return null;
            }

            ResumeMovement();
        }
    }
}