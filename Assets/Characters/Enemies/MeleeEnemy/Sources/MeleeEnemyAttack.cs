using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace Platformer.Characters.Enemy.MeleeEnemy
{
    public class MeleeEnemyAttack : MonoBehaviour
    {
        [SerializeField] private float delay = 0.5f;
        [SerializeField] private float offset = 0.5f;
        [SerializeField] private float attackClircleradius = 0.5f;
        [SerializeField] private int damage = 10;
        [SerializeField] private bool canRotate;
        private bool tooRight = true;
        public UnityEvent AttackStarted;

        public void Flip()
        {
            tooRight = !tooRight;
        }

        private IEnumerator Delay_hit(Health player)
        {

            for (float i = 0; i < delay; i += Time.deltaTime)
            {
                yield return null;
            }

            Vector2 point = transform.position;

            if (tooRight)
            {
                point += Vector2.right * offset;
            }
            else
            {
                point += Vector2.left * offset;
            }
            AttackStarted.Invoke();

            for (float i = 0; i < delay; i += Time.deltaTime)
            {
                yield return null;
            }
            Collider2D colliders = Physics2D.OverlapCircle(point, attackClircleradius, LayerMask.NameToLayer("player"));
            if (colliders != null)
            {
                player.TakeDamage(damage);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Health>(out var player))
            {
                StartCoroutine(Delay_hit(player));
            }
        }
    }
}

