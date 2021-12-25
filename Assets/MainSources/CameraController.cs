using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _zPosition = -10f;

    private CameraTarget _target;

    public void SetTarget(CameraTarget cameraTarget)
    {
        if (cameraTarget == null)
            throw new ArgumentNullException(nameof(cameraTarget));

        _target = cameraTarget;
    }
    private void LateUpdate()
    {
        var movement = Vector3.Lerp(transform.position,_target.Position,Time.deltaTime*_speed);
        movement.z = _zPosition;
        //movement = Vector3.ClampMagnitude(movement, _maxSpeed);
        transform.position = movement;
    }
}
