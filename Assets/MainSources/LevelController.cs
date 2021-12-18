using System;
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
    public event Action ExitPointReached;

    public void Init()
    {
        _startPoint.Reached += OnPointReached;
        _lastPoint = _startPoint;

        foreach (var point in _checkpoints)
        {
            point.Reached += OnPointReached;
        }

        _exitPosition.Reached += OnExitPointReached;
    }

    private void OnPointReached(LevelPoint point)
    {
        _lastPoint = point;
    }

    public void ReturnToLastPoint(IPlayerRespawn player)
    {
        player.Respawn(_lastPoint.Position);
    }

    private void OnExitPointReached(LevelPoint point)
    {
        ExitPointReached?.Invoke();
    }
}
