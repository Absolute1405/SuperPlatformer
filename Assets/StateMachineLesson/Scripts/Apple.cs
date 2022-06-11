using System;
using System.Threading.Tasks;
using UnityEngine;

namespace AppleGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Apple : MonoBehaviour
    {
        [SerializeField] private float _rotTime = 5f;
        [SerializeField] private float _stoneTime = 3f;

        public event Action<Apple> Disposed;

        private AppleStateMachine _stateMachine;
        private Rigidbody2D _rigidbody;

        public void Initialize()
        {
            gameObject.SetActive(false);
        }

        public void OnSpawn()
        {
            transform.localPosition = Vector3.zero;
        }

        private void Awake()
        {
            _stateMachine = new AppleStateMachine();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //if (other.gameObject.TryGetComponent<Player>(out var player))
            //{
            //    _stateMachine.Touch(player);
            //}
            //else // TODO check if ground
            //{
            //    _stateMachine.SetGroundedState();
            //    _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            //    WaitAndRot();
            //}
        }

        private async void WaitAndRot()
        {
            await Wait(_rotTime);
            _stateMachine.SetRottenState();
            WaitAndStone();
        }

        private async void WaitAndStone()
        {
            await Wait(_stoneTime);
            _stateMachine.SetStonedState();
        }

        private async Task Wait(float time)
        {
            var timeInt = (int)(time * 1000);
            await Task.Delay(timeInt);
        }

        public void Hit()
        {
            _stateMachine.Hit();
        }

        public void Dispose()
        {
            OnDispose();
            Disposed?.Invoke(this);
        }

        private void OnDispose()
        {
            //some logic
        }
    }
}

