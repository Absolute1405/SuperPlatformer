﻿using System;
using System.Collections;
using System.Collections.Generic;
using pEventBus;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour, IEventReceiver<PlayerHealthBarEvent>
{
    private Image bar => GetComponent<Image>();
    private int _maxValue = 100;

    private void Awake()
    {
        EventBus.Register(this);
    }

    private void OnDestroy()
    {
        EventBus.UnRegister(this);
    }

    public void OnEvent(PlayerHealthBarEvent e)
    {
        bar.fillAmount = (float)e.Value / _maxValue;
    }
}