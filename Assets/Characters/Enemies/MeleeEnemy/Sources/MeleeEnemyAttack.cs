using System;
using System.Collections;
using UnityEngine;


namespace Platformer.Characters.Enemy.MeleeEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class MeleeEnemyAttack : EnemyAttack
    {
        [SerializeField] private float _attackDuration = 1f;
        private Collider2D _collision;

        private void Awake()
        {
            _collision = GetComponent<Collider2D>();
            _collision.enabled = false;
        }

        public override void Attack()
        {
            base.Attack();

            StartCoroutine(CollisionLife());
        }

        private IEnumerator CollisionLife()
        {
            _collision.enabled = true;
            yield return new WaitForSeconds(_attackDuration);
            _collision.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage(Damage);
            }
        }
    }
}

