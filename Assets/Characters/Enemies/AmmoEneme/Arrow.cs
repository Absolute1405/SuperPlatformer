using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private ConfigsArrow _configs;
    private Rigidbody2D _rigidbody;
    private Vector2 _startsPoint;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startsPoint = transform.position;
    }
    public void Initialaze(Direction direction)
    {
       Vector2 move= DirectionGetter.GetVectorFromDirection(direction);
        _rigidbody.velocity =move*_configs.Speed;
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(_startsPoint, transform.position)>=_configs.Distance)
        {
            Destroy(gameObject);
        }
    }
}
