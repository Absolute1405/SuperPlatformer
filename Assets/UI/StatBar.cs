using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class StatBar : MonoBehaviour
{
    private Image _bar;
    private int _maxValue;

    public void Initialize(int maxValue)
    {
        if (maxValue < 0)
            return;

        _maxValue = maxValue;
        _bar = GetComponent<Image>();
    }

    public void RefreshBar(int value)
    {
        _bar.fillAmount = (float)value / _maxValue;
    }
}