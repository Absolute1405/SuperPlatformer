using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private StatBar _healthBar;
    public StatBar HealthBar => _healthBar;

    public void Initialize(PlayerConfig config)
    {
        _healthBar.Initialize(config.MaxHealth);
    }
}
