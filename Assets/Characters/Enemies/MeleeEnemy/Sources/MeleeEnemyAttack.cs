using System;
using System.Collections;
using UnityEngine;


namespace Platformer.Characters.Enemy.MeleeEnemy
{
    [RequireComponent(typeof(Collider2D))]
    public class MeleeEnemyAttack : MonoBehaviour,IAttack
    {
        [SerializeField] private float _attackDuration = 1f;
        private Collider2D _collision;
        private int _damage;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage(_damage);
            }
        }

        public void Initialize()
        {
            _collision = GetComponent<Collider2D>();
            _collision.enabled = false;
        }

        public IEnumerator Attack(IDamageable target, int damage)
        {
            yield return null;
        }

        public IEnumerator Attack(int damage)
        {
            _damage = damage;
            _collision.enabled = true;
            yield return new WaitForSeconds(_attackDuration);
            _collision.enabled = false;
        }
    }
}

