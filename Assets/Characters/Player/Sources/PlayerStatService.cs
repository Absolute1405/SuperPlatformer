using System;
using pEventBus;
public class PlayerStatService: IEventReceiver<InitializeBarEvent>, IEventReceiver<RefreshBarEvent>
{
    private const int _damage = 5; // TODO to config
    private readonly Stat _stamina;
    private readonly Stat _health;
    private readonly Stat _sleep;

    public event Action<int> StaminaChanged;
    public event Action<int> SleepChanged;
    public event Action<int> HealthChanged;
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

    private void OnStaminaChanged(int value) => StaminaChanged?.Invoke(value);
    private void OnSleepChanged(int value) => SleepChanged?.Invoke(value);
    private void OnHealthChanged(int value) => HealthChanged?.Invoke(value);
    private void OnDeath() => Death?.Invoke();

    public void TakeDamage(Damage damage)
    {
        //TODO

        _health.Decrease(damage.Value);
         
    }

    public void OnEvent(InitializeBarEvent e)
    {
        _health.SetFull();
    }

    public void OnEvent(RefreshBarEvent e)
    {
        throw new NotImplementedException();
    }
}
