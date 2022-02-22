using System;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerRespawn
{
    [Header("Components")]
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerAnimator _animations;
    [SerializeField] private CharacterAttack _attack;
    [SerializeField] private CharacterDirection _direction;
    [SerializeField] private Weapon _weapon;

    private const int _StaminDamage = 10;

    private int _maxStamina = 100;
    private int _maxSleep=4;
    private int _maxHealth = 100;
    private float _jumpForce = 20f;
    private float _maxSpeed = 5f;
    private float _acceleration = 0.2f;
    
    private PlayerStatService _statService;

    public event Action<int> HealthChanged;
    public event Action<int> StaminaChanged;
    public event Action<int> SleepChanged;
    public event Action Died;

    public void Init(Vector3 startPosition, PlayerConfig config)
    {
        _maxHealth = config.MaxHealth;
        _jumpForce = config.JumpForce;
        _maxSpeed = config.MaxSpeed;
        _acceleration = config.Acceleration;
        _maxStamina = config.MaxStamina;

        var health = new Stat(_maxHealth);
        health.Abandoned += OnDied;
        health.ValueChanged += (x) => HealthChanged?.Invoke(x);

        var stamina = new Stat(_maxStamina);
        stamina.ValueChanged += (x) => StaminaChanged?.Invoke(x);

        var sleep = new Stat(config.MaxSleep);
        sleep.ValueChanged += (x) => SleepChanged?.Invoke(x);

        _statService = new PlayerStatService(stamina, health, sleep);

        _direction.ValueChanged += _attack.UpdateDirection;
        _physics.Initialize(_jumpForce, _maxSpeed, _acceleration);

        _attack.Initialize(_weapon); // tmp weapon
    }

    public void Attack()
    {
        _attack.StartCoroutine(_attack.Attack());
        _animations.Attack();
    }

    public void Respawn(Vector3 point)
    {
        _statService.SetFullHealth();
        //HealthChanged?.Invoke(_health.Value); TODO
        transform.position = point;
        _physics.SetActive(true);
        _animations.Revive();
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
    

    public void TakeDamage(Damage damage)
    {
        _statService.TakeDamage(damage);
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

