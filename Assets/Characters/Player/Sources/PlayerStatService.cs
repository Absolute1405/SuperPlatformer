using System;

public class PlayerStatService
{
    private const int _damage = 5; // TODO to config
    private readonly Stat _stamina;
    private readonly Stat _health;
    private readonly Stat _sleep;

    public event Action<int> StaminaChanged;
    public event Action<int> SleepChanged;
    public event Action<int> HealthChanged;

    public PlayerStatService(Stat stamina, Stat health, Stat sleep)
    {
        if (stamina is null)
            throw new ArgumentNullException(nameof(stamina));

        if (health is null)
            throw new ArgumentNullException(nameof(health));

        if (sleep is null)
            throw new ArgumentNullException(nameof(sleep));

        _stamina = stamina;
        _health = health;
        _sleep = sleep;

        _stamina.ValueChanged += OnStaminaChanged;
        _sleep.ValueChanged += OnSleepChanged;
        _health.ValueChanged += OnHealthChanged;
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

    public void OnStaminaChanged(int value) => StaminaChanged?.Invoke(value);
    public void OnSleepChanged(int value) => SleepChanged?.Invoke(value);
    public void OnHealthChanged(int value) => HealthChanged?.Invoke(value);

    public void TakeDamage(Damage damage)
    {
        //TODO

        _health.Decrease(damage.Value);
    }
}
