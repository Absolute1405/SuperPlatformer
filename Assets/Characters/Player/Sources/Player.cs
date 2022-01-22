using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerRespawn
{
    [Header("Components")]
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerAnimator _animations;
    [SerializeField] private CharacterAttack _attack;
    [SerializeField] private CharacterDirection _direction;

    private const int _StaminDamage = 10;

    private int _maxStamina = 100;
    private int _maxSleep=4;
    private int _maxHealth = 100;
    private int _damage = 10;
    private float _jumpForce = 20f;
    private float _maxSpeed = 5f;
    private float _acceleration = 0.2f;
    
    private Health _health;
    private PlayerStatService _statService;
    

    public event Action<int> HealthChanged;
    public event Action<int> StaminaChanged;
    public event Action<int> SleepChanged;
    public event Action Died;

    public void Init(Vector3 startPosition, PlayerConfig config)
    {
        _maxHealth = config.MaxHealth;
        _damage = config.Damage;
        _jumpForce = config.JumpForce;
        _maxSpeed = config.MaxSpeed;
        _acceleration = config.Acceleration;
        _maxStamina = config.MaxStamina;

        _health = new Health(_maxHealth);
        _health.Death += OnDied;

        _health.ValueChanged += (x) => HealthChanged?.Invoke(x);

        var stamina = new Stamina(_maxStamina);
        stamina.ValueChanged += (x) => StaminaChanged?.Invoke(x);

        var sleep = new Sleep(config.MaxSleep);
        sleep.ValueChanged += (x) => SleepChanged?.Invoke(x);

        _statService = new PlayerStatService(stamina, _health, sleep);

        _direction.ValueChanged += _attack.UpdateDirection;
        _physics.Initialize(_jumpForce, _maxSpeed, _acceleration);

        
    }

    public void Respawn(Vector3 point)
    {
        _health.SetFull();
        HealthChanged?.Invoke(_health.Value);
        transform.position = point;
        _physics.SetActive(true);
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
            _direction.Set(Direction.Left);
        }
        else if (input > 0)
        {
            _direction.Set(Direction.Right);
        }

        _animations.SetFlip(_direction.Value == Direction.Left);

    }
    

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void FixedUpdate()
    {
        _animations.SetGrounded(_physics.Grounded);
    }

    private void OnDied()
    {
        _animations.Death();
        _physics.SetActive(false);
        Died?.Invoke();
    }
}

