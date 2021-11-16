using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Platformer.Characters.Enemy.MeleeEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class MeleeEnemyAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private float _attackDuration = 1f;
        private Collider2D _collision;
        private int _damage;
        private IDamageable _tmpTarget;

        private void Awake()
        {
            _collision = GetComponent<Collider2D>();
        }

        public void Initialize(int damage)
        {
            _damage = damage;
        }

        public void Attack(IDamageable target)
        {
            _tmpTarget = target;
            StartCoroutine(CollisionLife());
        }

        private IEnumerator CollisionLife()
        {
            _collision.enabled = true;
            yield return new WaitForSeconds(_attackDuration);
            _collision.enabled = false;
            _tmpTarget = null;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                if (target == _tmpTarget)
                    target.TakeDamage(_damage);
            }
        }
    }
}

