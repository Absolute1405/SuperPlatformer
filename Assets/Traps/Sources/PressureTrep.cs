using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatorPressureTrep : Trap
{
    public UnityEvent TrapOn;
    public UnityEvent TrapOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var target))
        {
            if (collision != null)
            {
                TrapOn?.Invoke();
            }
            if (collision = null)
            {
                TrapOff?.Invoke();
            }
        }
        
    }

}
