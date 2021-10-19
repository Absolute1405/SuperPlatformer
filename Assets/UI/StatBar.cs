using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class StatBar : MonoBehaviour
{
    private Slider _bar;
    private int _maxValue;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    public void Initialize(int maxValue)
    {
        if (maxValue < 0)
            return;

        _maxValue = maxValue;
    }

    public void RefreshBar(int value)
    {
        _bar.value = (float)value / _maxValue;
    }
}