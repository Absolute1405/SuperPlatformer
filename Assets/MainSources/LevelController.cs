using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelPoint _startPoint;
    [SerializeField] private LevelPoint _exitPosition;

    [SerializeField] private LevelPoint[] _checkpoints;

    public Vector3 StartPosition => _startPoint.Position;

}
