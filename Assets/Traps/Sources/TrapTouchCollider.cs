using System;
using UnityEngine;

public class TrapTouchCollider : MonoBehaviour
{
    public event Action<IDamageable> TargetTouched;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out var target))
        {
            TargetTouched?.Invoke(target);
        }
    }
}
