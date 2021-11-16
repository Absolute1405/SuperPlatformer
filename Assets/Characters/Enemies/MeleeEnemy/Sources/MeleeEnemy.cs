using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private Transform _BTransform;
    private Vector2 _vector2Ride;
    private Vector2 _vector2Left;
    public override void Initialize(EnemyConfig config)
    {
        base.Initialize(config);
        
        BanditConfig banditConfig = config as BanditConfig;
        _vector2Ride =new Vector2(_BTransform.position.x, _BTransform.position.y) + new Vector2( banditConfig.MoveRange,0);
        _vector2Ride = new Vector2(_BTransform.position.x, _BTransform.position.y) - new Vector2(banditConfig.MoveRange, 0);
    }

    protected override IEnumerator LifeCycle()
    {
        while (true)
        {
            _BTransform.Translate(_vector2Ride);
            yield return new WaitForSeconds(1f);
            _BTransform.Translate(_vector2Left);
        }
    }
}