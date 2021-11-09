using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundOverlapRadius = 0.5f;
    [SerializeField] private Transform _groundPoint;

    private Rigidbody2D _rigidbody;
    private GroundProps _groundProps;

    private float _jumpForce;
    private float _maxSpeed;
    private float _velocityX;
    private float _acceleration;

    public bool Grounded { get; private set; }
    

    public void Initialize(float jumpForce, float maxSpeed, float acceleration)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpForce = jumpForce;
        _maxSpeed = maxSpeed;
        _acceleration = acceleration;
    }

    public void Move(float input)
    {
        _velocityX += input * _acceleration;
        _velocityX = Mathf.Clamp(_velocityX, -_maxSpeed, _maxSpeed);
    }

    public void Jump()
    {
       _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        
    }

    public void SetActive(bool value)
    {
        if (value)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ground>(out var ground))
        {
            _groundProps = ground.Properties;
        }
    }

    private void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(_groundPoint.position, _groundOverlapRadius, _groundLayer) != null;
        _rigidbody.velocity = new Vector2(_velocityX, _rigidbody.velocity.y);
        _velocityX = Mathf.Lerp(_velocityX, 0, 1 / _groundProps.Slip);
    }

    
}
