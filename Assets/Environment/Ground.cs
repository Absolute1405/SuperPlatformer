using System;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GroundProps _properties;

    public GroundProps Properties => _properties;
}