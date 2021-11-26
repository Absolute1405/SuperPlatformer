using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    private float _delay;
    private float _range;
    private Arrow _prefab;
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        ArcherConfig archerConfig = config as ArcherConfig;
        _delay = archerConfig.AttackDelay;
        _prefab = archerConfig.ArrowPrefab;
        _range = archerConfig.AttackRange;
    }
    protected override IEnumerator LifeCycle()
    {
        Instantiate(_prefab);
        yield return new WaitForSeconds(_delay);
    }
}
