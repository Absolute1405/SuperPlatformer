using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    private System.Random random;
    private void Start()
    {
        random= new System.Random();
        var _vale = random.Next(10, 30);
        Debug.Log(_vale);

    }
}
