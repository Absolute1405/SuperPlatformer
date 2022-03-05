using System;
using pEventBus;
public class PlayerStatService
{
    private const int _damage = 5; // TODO to config
    private readonly Stat _stamina;
    private readonly Stat _health;
    private readonly Stat _sleep;

    public event Action<int> SleepChanged;
    public event Action Death;

    public PlayerStatService(int maxStamina, int maxHealth, int maxSleep)
    {
        _stamina=new Stat(maxStamina);
        _health = new Stat(maxHealth);
        _sleep = new Stat(maxSleep);

        _stamina.ValueChanged += OnStaminaChanged;
        _sleep.ValueChanged += OnSleepChanged;
        _health.ValueChanged += OnHealthChanged;
        _health.Abandoned += OnDeath;
    }

    public void SetFullHealth()
    {
        _health.SetFull();
        EventBus<PlayerHealthBarEvent>.Raise(new PlayerHealthBarEvent(_health.Value, _health.MaxValue));
    }

    public void SetFullStamina()
    {
        _stamina.SetFull();
        EventBus<PlayerHealthBarEvent>.Raise(new PlayerHealthBarEvent(_health.Value, _health.MaxValue));
    }

    public void Action(int staminaRequired)
    {
        if (_stamina.Value <= 0)
        {
            if (_sleep.Value > 0)
            {
                _sleep.Decrease(1);
                _stamina.SetFull();
            }
            else
            {
                _health.Decrease(_damage);
            }
        }
        else
        {
            _stamina.Decrease(staminaRequired);
        }
    }

    private void OnStaminaChanged(int value) 
        => EventBus<PlayerStaminaBarEvent>.Raise(new PlayerStaminaBarEvent(_stamina.Value, _stamina.MaxValue));
    private void OnSleepChanged(int value) => SleepChanged?.Invoke(value);

    private void OnHealthChanged(int value) 
        => EventBus<PlayerHealthBarEvent>.Raise(new PlayerHealthBarEvent(_health.Value, _health.MaxValue));

    private void OnDeath() => Death?.Invoke();

    public void TakeDamage(Damage damage)
    {
        //TODO

        _health.Decrease(damage.Value);
         
    }
}
