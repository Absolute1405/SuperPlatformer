using System;
using UnityEngine;

[Serializable]
public struct GroundProps
{
    [SerializeField, Min(0.01f)] private float _slip;

    public float Slip => _slip;
}
