using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        BanditConfig banditConfig = config as BanditConfig;
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
        }
    }
}