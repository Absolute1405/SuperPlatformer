using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ButtonOrderController : MonoBehaviour
{
    [SerializeField] private ButtonTrap[] _buttonTraps;

    private void Start()
    {
        WaitPressInOrder();
    }

    private async void WaitPressInOrder()
    {
        foreach (var button in _buttonTraps)
        {
            await button.WaitForClick();
        }

        Debug.Log("Win");
    }
}
