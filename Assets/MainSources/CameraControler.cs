using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private float _maxSpeed=0.01f;
    [SerializeField]private float _Z

    private CameraTarget _target;

    public void SetTarget(CameraTarget cameraTarget)
    {
        if (cameraTarget == null)
            throw new ArgumentNullException(nameof(cameraTarget));

        _target = cameraTarget;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,_target.Position,Time.deltaTime*_maxSpeed);
        transform.position = 
    }
}
