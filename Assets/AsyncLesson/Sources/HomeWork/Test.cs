using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Button _button;
    private TaskCompletionSource<bool> _task;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }
    
    public async void Metod()
    {
        await _task.Task;
        Debug.Log("Что-то");
        

    }
    private void OnClick()
    {
        _task.SetResult(true);
    }
}
