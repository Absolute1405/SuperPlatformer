using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private EnemyConfig _config;
    private List<Enemy> _enemies = new List<Enemy>();
    
    public void Initialize()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        if (enemies.Length == 0)
            return;

        foreach (var enemy in enemies)
        {
            enemy.Initialize(_config);
        }

        _enemies.AddRange(enemies);
    }

    public void Dispose()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        if (enemies.Length == 0)
            return;

        foreach (var enemy in enemies)
        {
            enemy.Dispose();
        }
    }
}
