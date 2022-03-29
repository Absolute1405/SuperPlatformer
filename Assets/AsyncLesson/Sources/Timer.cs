using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private int _timerDeiay;
    [SerializeField] private int _repetition = 5;
    public async Task TamerAsync()
    {
        for (int i=5;i>=0;i--)
        {
            _text.text = i.ToString();
            await Task.Delay(_timerDeiay);
        }
        
    }
}
