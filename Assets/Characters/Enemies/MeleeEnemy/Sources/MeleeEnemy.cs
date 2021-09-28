using UnityEngine;

namespace Platformer.Characters.Enemy.MeleeEnemy
{
    public class MeleeEnemy : MonoBehaviour
    {
        [SerializeField] private MeleeEnemyAttack _attack;
        [SerializeField] private EnemyBoundXMovement _movement;
        [SerializeField] private MeleeEnemyAnimator _animator;
        [SerializeField] private Health _health;

        public bool DirectedRight { get; private set; }

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            DirectedRight = true;
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            _movement.Init(rigidbody);
            _animator.Run(true);
            _health.SetFull();
        }

        public void Flip()
        {
            DirectedRight = !DirectedRight;
            _animator.DirectToRight(DirectedRight);
        }

    }
}