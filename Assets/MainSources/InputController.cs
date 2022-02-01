using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<float> HorizontalAxisChanged;
    public event Action SpacePressed;
    public event Action LMousePressed;

    private void Update()
    {
        HorizontalAxisChanged?.Invoke(Input.GetAxis("Horizontal"));

        
        if (Input.GetKeyDown(KeyCode.Space))
            SpacePressed?.Invoke();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            LMousePressed?.Invoke();
    }
}
