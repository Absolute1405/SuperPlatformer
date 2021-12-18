using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [Header("Components")]
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerAnimator _animations;

    private const int _StaminDamage = 10;

    private int _maxStamina = 100;
    private int _maxSleep=4;
    private int _maxHealth = 100;
    private int _damage = 10;
    private float _jumpForce = 20f;
    private float _maxSpeed = 5f;
    private float _acceleration = 0.2f;
    
    private Health _health;
    private PlayerAttack _attack;
    private PlayerStatService _statService;
    private bool _directedRight;

    private Vector3 _startPosition;

    public event Action<int> HealthChanged;
    public event Action<int> StaminaChanged;
    public event Action<int> SleepChanged;

    public void Init(Vector3 startPosition, PlayerConfig config)
    {
        _maxHealth = config.MaxHealth;
        _damage = config.Damage;
        _jumpForce = config.JumpForce;
        _maxSpeed = config.MaxSpeed;
        _acceleration = config.Acceleration;
        _maxStamina = config.MaxStamina;

        _health = new Health(_maxHealth);
        _health.Death += () => _physics.SetActive(false);
        _health.Death += _animations.Death;
        _health.ValueChanged += (x) => HealthChanged?.Invoke(x);

        var stamina = new Stamina(_maxStamina);
        stamina.ValueChanged += (x) => StaminaChanged?.Invoke(x);

        var sleep = new Sleep(config.MaxSleep);
        sleep.ValueChanged += (x) => SleepChanged?.Invoke(x);

        _statService = new PlayerStatService(stamina, _health, sleep);

        _physics.Initialize(_jumpForce, _maxSpeed, _acceleration);

        _startPosition = startPosition;
        _directedRight = true;
    }

    public void Respawn(Vector3 point)
    {
        HealthChanged?.Invoke(_health.Value);
        _health.SetFull();
        transform.position = point;
    }

    public void Jump()
    {
        
        if(!_physics.Grounded)
        {
            return;
        }
        _physics.Jump();
        _statService.Action(_StaminDamage);
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

