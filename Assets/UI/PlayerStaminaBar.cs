using System.Collections;
using System.Collections.Generic;
using pEventBus;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour, IEventReceiver<PlayerStaminaBarEvent>
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

    public void OnEvent(PlayerStaminaBarEvent e)
    {
        bar.fillAmount = (float)e.Value / _maxValue;
    }
}
