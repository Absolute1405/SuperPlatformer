using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Arrow _prefab;
    [SerializeField] private Collider2D _enemyCollider;

    private ICharacterDirection _direction;
    private float _spawnOffset;

    public IEnumerator Attack(IDamageable target, int damage)
    {
        yield return null;
    }

    public IEnumerator Attack(int damage)
    {
        Vector2 arrowPosition = transform.position;
        arrowPosition += DirectionGetter.GetVectorFromDirection(_direction.Value) * _spawnOffset;
        var arrow = Instantiate(_prefab, arrowPosition, Quaternion.identity, transform);
        arrow.Initialize(_direction.Value);
        yield return null;
    }

    public void Initialize()
    {
        _direction = GetComponent<ICharacterDirection>();

        if (_direction.Value == Direction.None)
            throw new ArgumentException("None direction");

        _enemyCollider = GetComponent<Collider2D>();

        if (_enemyCollider is null)
            throw new ArgumentNullException();

        _spawnOffset = _enemyCollider.bounds.size.x / 2;
    }
}
