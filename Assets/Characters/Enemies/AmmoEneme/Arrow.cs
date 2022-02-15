using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private ConfigsArrow _configs;

    private Vector2 _startsPoint;
    private bool _active;
    private Vector2 _movement;
    
    public void Initialize(Direction direction)
    {
       Vector3 move= DirectionGetter.GetVectorFromDirection(direction);
       _movement = move * _configs.Speed;
       _startsPoint = transform.position + move * _configs.Length;

       _active = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(_movement * Time.deltaTime);

        if (Vector2.Distance(_startsPoint, transform.position)>=_configs.Distance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_active == false) return;

        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            var damage = _configs.GetDamage();
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
