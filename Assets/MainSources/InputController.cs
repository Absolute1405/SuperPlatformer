using System;
using UnityEngine;
using pEventBus;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        EventBus<InputHorizontalEvent>.Raise(new InputHorizontalEvent(Input.GetAxis("Horizontal")));

        if (Input.GetKeyDown(KeyCode.Space))
            EventBus<InputSpaceEvent>.Raise(new InputSpaceEvent());
        if (Input.GetKeyDown(KeyCode.Mouse0))
            EventBus<InputLMouseEvent>.Raise(new InputLMouseEvent());
    }
}
