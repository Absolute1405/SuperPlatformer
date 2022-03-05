using pEventBus;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSleepBar : MonoBehaviour,IEventReceiver<PlayerSleepBarEvent>
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

    public void OnEvent(PlayerSleepBarEvent e)
    {
        bar.fillAmount = (float)e.Value / _maxValue;
    }
}
