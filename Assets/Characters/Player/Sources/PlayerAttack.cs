using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack :MonoBehaviour, IAttack
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackDuration = 1f;

    private Direction _direction;

    private Collider2D _collision;

    public void UpdateDirection(Direction direction)
    {
        _direction = direction;
    }

    public void Initialize()
    {
        _collision = GetComponent<Collider2D>();
        _collision.isTrigger = true;
        _collision.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out var damageable))
        {
            if (collision.gameObject.layer == _enemyLayer)
            {
                damageable.TakeDamage(_damage);
            }
            
        }
        
    }

    public IEnumerator Attack(IDamageable target, int damage)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Attack(int damage)
    {
        _damage = damage;
        _collision.enabled = true;
        yield return new WaitForSeconds(_attackDuration);
        _collision.enabled = false;
    }
}