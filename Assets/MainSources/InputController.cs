using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<float> HorizontalAxisChanged;
    public event Action SpacePressed;

    private void Update()
    {
        HorizontalAxisChanged?.Invoke(Input.GetAxis("Horizontal"));

        
        if (Input.GetKeyDown(KeyCode.Space))
            SpacePressed?.Invoke();
    }
}
