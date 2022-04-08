using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    private System.Random random;
    public bool theCrit => TheCritical();
    private void Start()
    {
        random= new System.Random();
        var _vale = random.Next(0, 100);
        Debug.Log(_vale);

    }
    private bool TheCritical()
    {
        bool Bool=false;
        var _vale = random.Next(0, 100);
        if (_vale <= 10)
        {
            Bool = true;
            return Bool;
        }
        else
        {
            return Bool;
        }
    }
    
}
