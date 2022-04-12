using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonTrap : MonoBehaviour
{
    private Button Button => GetComponent<Button>();

    private TaskCompletionSource<bool> _clicked;
    private bool _correct;

    private void Awake()
    {
        Button.onClick.AddListener(OnClick);
    }

    public async Task WaitForClick()
    {
        _clicked = new TaskCompletionSource<bool>();
        _correct = true;
        await _clicked.Task;
        _correct = false;
    }

    private void OnClick()
    {
        if (_correct == false)
        {
            Debug.LogError("WRONG");
            return;
        }

        _clicked.SetResult(true);
    }
}
