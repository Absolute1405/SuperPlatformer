using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : IAttack
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _range = 1f;
    [SerializeField] private LayerMask _enemyLayer;

    private const float _overlapRadius = 0.25f;

    private SpriteRenderer _renderer;
    private PlayerAnimator _animator;

    public void Init(SpriteRenderer renderer, PlayerAnimator animator)
    {
        _renderer = renderer;
        _animator = animator;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = transform.position;
            Vector2 side = Vector2.right;

            if (_renderer.flipX)
            {
                side = Vector2.left;
            }

            point += side * _range;
            point += Vector2.down;
            Collider2D collider = Physics2D.OverlapCircle(point, _overlapRadius, _enemyLayer);
            _animator.Attack();

            if (collider == null)
            {
                return;
            }

            if (collider.gameObject.TryGetComponent<Health>(out var enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }
}