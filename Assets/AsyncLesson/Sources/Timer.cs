using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerView;
    private float _duration;

    public async void Setup(float _duration)
    { 
        for(float i=0; i <= 0; i = _duration)
        {
            _duration -= Time.deltaTime;
            _timerView.text = _duration.ToString("F1");

            await Task.Run(() => Stop());
            Debug.Log("Остановка Выполнена");
        }
    }

    public void TimerUpdate(float Valu)
    {
        
    }                  

    public void Stop()
    {
        Debug.Log("Остановка Выполнена?");

    }

}
