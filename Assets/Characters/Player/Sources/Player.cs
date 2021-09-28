using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerAnimator _animations;
    [SerializeField] private PlayerStatsUI _interface;

    [Header("Parameters")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _acceleration = 0.2f;

    private Health _health;
    private PlayerAttack _attack;
    private bool _directedRight;
    private float _lastInput;

    private Vector3 _startPosition;

    public void Init(Vector3 startPosition)
    {
        _health = new Health(_maxHealth);
        _health.Death += () => _physics.SetActive(false);
        _health.Death += _animations.Death;

        _physics.Initialize(_jumpForce, _maxSpeed, _acceleration);

        _startPosition = startPosition;
        _directedRight = true;
    }

    public void Restart()
    {
        _health.SetFull();
        transform.position = _startPosition;
    }

    public void Jump()
    {
        _physics.Jump();
    }

    public void Move(float input)
    {
        _animations.Move(Mathf.Approximately(input,0) == false);

        _physics.Move(input);

        if (input < 0)
        {
            _directedRight = false;
        }
        else if (input > 0)
        {
            _directedRight = true;
        }

        _animations.SetFlip(_directedRight == false);

    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
        _animations.SetGrounded(_physics.Grounded);
    }
}

