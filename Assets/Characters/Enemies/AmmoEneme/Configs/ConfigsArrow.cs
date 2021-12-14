﻿using UnityEngine;
[CreateAssetMenu(fileName = "New Arrow Config", menuName = "Configs/Ammo/Arrow", order = 0)]
public class ConfigsArrow : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private float _length;

    public float Speed => _speed;
    public float Distance => _distance;
    public int Damage => _damage;
    public float Length => _length;

}
