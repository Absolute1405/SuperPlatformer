using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap, ITimerTrap
{
    [SerializeField] private SpikeTrapConfig _config;
    [SerializeField] private SpikesAnimation _animation;
    private IDamageable _target;

    public float Timer { get; private set; }

    

    public override void Initialize()
    {
        base.Initialize();
        Timer = _config.Timer;
        Damage = new Damage(_config.Damage, _config.Type);
        StartCoroutine(WaitAndHit());
    }

    public IEnumerator WaitAndHit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Timer);
            _animation.Activate();
            Debug.Log("spikes activated");

            if (_target is null == false)
            {
                _target.TakeDamage(Damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.TryGetComponent<IDamageable>(out var target);
        Debug.Log(other.gameObject.name + " exit");
        _target = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<IDamageable>(out var target);
        Debug.Log(other.gameObject.name + " entry");

        _target = target;
    }
}
