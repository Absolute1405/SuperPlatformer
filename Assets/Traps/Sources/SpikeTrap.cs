using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap, ITimerTrap
{
    [SerializeField] private SpikeTrapConfig _config;
    private IDamageable _target;

    public float Timer { get; private set; }

    

    public override void Initialize()
    {
        Timer = _config.Timer;
        Damage = _config.Damage;
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
        other.TryGetComponent<IDamageable>(out var target);
        _target = target;
    }
}
