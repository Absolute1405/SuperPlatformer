using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirection : MonoBehaviour, ICharacterDirection
{
    [SerializeField] private Direction _startDirection;
    public Direction Value { get; private set; }

    public event Action<Direction> ValueChanged;

    public void Set(Direction direction)
    {
        _startDirection = direction;
    }
}

public interface ICharacterDirection
{
    Direction Value { get; }

    event Action<Direction> ValueChanged;
}
