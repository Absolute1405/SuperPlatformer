using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelPoint _startPoint;
    [SerializeField] private LevelPoint _exitPosition;

    [SerializeField] private LevelPoint[] _checkpoints;
    private LevelPoint _lastPoint;

    public Vector3 StartPosition => _startPoint.Position;
    public void Init ()
    {
        _startPoint.Reached += OnPointReached;
    }

    private void OnPointReached(LevelPoint point)
    {
        _lastPoint = point;
    }
    public void ReturnToLastPoint()
    {

    }
}
