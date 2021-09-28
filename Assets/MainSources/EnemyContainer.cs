using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    private List<Enemy> _enemies;

    public void Initialize()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        if (enemies.Length == 0)
            return;

        _enemies.AddRange(enemies);

    }
}
