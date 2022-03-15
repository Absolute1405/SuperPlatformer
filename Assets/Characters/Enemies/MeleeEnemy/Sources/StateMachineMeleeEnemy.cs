using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMeleeEnemy
{
    private MeleeEnemyState _moveState;
    private MeleeEnemyState _attackState;
    private MeleeEnemyState _hitState;
    private MeleeEnemyState _deathstate;
    public StateMachineMeleeEnemy(MeleeEnemyAnimator animator)
    {

    }
}
