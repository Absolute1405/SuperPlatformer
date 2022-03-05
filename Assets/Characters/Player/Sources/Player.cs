using System;
using pEventBus;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerDamageable, IPlayerRespawn, IEventReceiver<InputHorizontalEvent>, IEventReceiver<InputSpaceEvent>, IEventReceiver<InputLMouseEvent>
{
    [Header("Components")]
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerAnimator _animations;
    [SerializeField] private CharacterAttack _attack;
    [SerializeField] private CharacterDirection _direction;
    [SerializeField] private Weapon _weapon;

    private const int _StaminDamage = 10;

    private float _jumpForce = 20f;
    private float _maxSpeed = 5f;
    private float _acceleration = 0.2f;
    
    private PlayerStatService _statService;

    private void Awake()
    {
        EventBus.Register(this);
    }

    private void OnDestroy()
    {
        EventBus.UnRegister(this);
    }

    public void Init(Vector3 startPosition, PlayerConfig config)
    {
        _jumpForce = config.JumpForce;
        _maxSpeed = config.MaxSpeed;
        _acceleration = config.Acceleration;

        _statService = new PlayerStatService(config.MaxStamina,config.MaxHealth,config.MaxSleep);

        _direction.ValueChanged += _attack.UpdateDirection;
        _physics.Initialize(_jumpForce, _maxSpeed, _acceleration);

        _statService.Death += OnDied;

        _attack.Initialize(_weapon); // tmp weapon
    }

    public void Respawn(Vector3 point)
    {
        _statService.SetFullHealth();
        _statService.SetFullStamina();

        transform.position = point;
        _physics.SetActive(true);
        _animations.Revive();
    }

    public void TakeDamage(Damage damage)
    {
        _statService.TakeDamage(damage);
        //animation etc.
    }

    private void FixedUpdate()
    {
        _animations.SetGrounded(_physics.Grounded);
    }

    private void OnDied()
    {
        _animations.Death();
        _physics.SetActive(false);
    }

    public void OnEvent(InputHorizontalEvent e)
    {
        var input = e.Value;
        _animations.Move(Mathf.Approximately(input, 0) == false);

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

    public void OnEvent(InputSpaceEvent e)
    {
        if (!_physics.Grounded)
        {
            return;
        }
        _physics.Jump();
        _statService.Action(_StaminDamage);
    }

    public void OnEvent(InputLMouseEvent e)
    {
        _attack.StartCoroutine(_attack.Attack());
        _animations.Attack();
    }
}



