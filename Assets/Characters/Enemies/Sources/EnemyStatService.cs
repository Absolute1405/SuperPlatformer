using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatService 
{
    private readonly Stat _health;
    public event Action<int> HealthChanged;

    public EnemyStatService(Stat health)
    {
        _health = health;
        _health.ValueChanged += OnHealthChanged;
    }

    public void OnHealthChanged(int value) => HealthChanged?.Invoke(value);

    public void TakeDamage(Damage damage)
    {
        //TODO

        _health.Decrease(damage.Value);
    }
}
