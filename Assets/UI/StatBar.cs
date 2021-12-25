using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class StatBar : MonoBehaviour
{
    private Slider _bar;
    private int _maxValue;

    public void Initialize(int maxValue)
    {
        if (maxValue < 0)
            return;

        _maxValue = maxValue;
        _bar = GetComponent<Slider>();
    }

    public void RefreshBar(int value)
    {
        _bar.value = (float)value / _maxValue;
    }
}