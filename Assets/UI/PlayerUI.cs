using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private StatBar _healthBar;
    [SerializeField] private StatBar _staminaBar;
    [SerializeField] private StatBar _sleepBar;

    public StatBar HealthBar => _healthBar;
    public StatBar StaminaBar => _staminaBar;
    public StatBar SleepBar => _sleepBar;


    public void Initialize(PlayerConfig config)
    {
        _healthBar.Initialize(config.MaxHealth);
        _staminaBar.Initialize(config.MaxStamina);
        _sleepBar.Initialize(config.MaxSleep);
    }
}
