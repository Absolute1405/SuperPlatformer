using UnityEngine;

namespace Platformer.Characters.Enemy.MeleeEnemy
{
    public class MeleeEnemyAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _runBool = "Run";
        [SerializeField] private string _hurtTrigger = "Hurt";
        [SerializeField] private string _deathTrigger = "Death";
        [SerializeField] private string _attackTrigger = "Attack";

        public void DirectToRight(bool value)
        {
            _renderer.flipX = value;
        }

        public void Run(bool value)
        {
            _animator.SetBool(_runBool, value);
        }

        public void Attack()
        {
            _animator.SetTrigger(_attackTrigger);
        }

        public void Hurt()
        {
            _animator.SetTrigger(_hurtTrigger);
        }

        public void Die()
        {
            _animator.SetTrigger(_deathTrigger);
        }
    }
}