using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap, ITimerTrap
{
    private Health _target;

    public float Timer { get; private set; }

    public override void Hit(Health target)
    {
        target.TakeDamage(Damage);
    }

    public override void Initialize()
    {
        StartCoroutine(WaitAndHit());
    }

    public IEnumerator WaitAndHit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Timer);

            if (_target is null == false)
            {
                _target.TakeDamage(Damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.TryGetComponent<Health>(out var target);
        _target = target;
    }
}
