using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerView;
    private float _timer;

    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerView.text = _timer.ToString("F1");
    }

    public void Setup(float duration)
    {
        _timer = duration;
        enabled = true;
    }

    public void Stop()
    {
        enabled = false;
    }

}
