using System;

public class PlayerStatService
{
    private const int _damage = 5;
    private readonly Stamina _stamina;
    private readonly Health _health;
    private readonly Sleep _sleep;

    public PlayerStatService(Stamina stamina, Health health, Sleep sleep)
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
    }

    public void Action(int staminaRequired)
    {
        if (_stamina.Value <= 0)
        {
            if (_sleep.Value > 0)
            {
                _sleep.Decrease();
                _stamina.SetFull();
            }
            else
            {
                _health.TakeDamage(_damage);
            }
            
        }
        else
        {
            _stamina.Decrease(staminaRequired);
        }
    }
}
