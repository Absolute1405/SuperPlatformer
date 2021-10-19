using System;
using Platformer.Characters;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour
{
    private Slider _bar;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    public void RefreshBar(int health, int maxHealth)
    {
        _bar.value = (float)health / maxHealth;
    }
}