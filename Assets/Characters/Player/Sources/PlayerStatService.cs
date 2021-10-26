using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatService
{
    private readonly Stamina _stamina;
    private readonly Health _health;
    // add sleep class

    public PlayerStatService(Stamina stamina, Health health)
    {
        if (stamina is null)
            throw new ArgumentNullException(nameof(stamina));

        if (health is null)
            throw new ArgumentNullException(nameof(health));

        _stamina = stamina;
        _health = health;
    }

    public void Action(int staminaRequired)
    {
        // 1) check stamina
        // 2) if stamina cant be decreased => fill stamina with sleep
        // 3) if has no sleep points => decrease health
    }
}
