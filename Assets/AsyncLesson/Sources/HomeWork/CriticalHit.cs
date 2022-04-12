using System;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    [SerializeField] private int _criticalChance = 10;

    public bool TakeCriticalByChance()
    {
        var value = UnityEngine.Random.Range(0, 100);
        return value <= _criticalChance;
    }
    
}
