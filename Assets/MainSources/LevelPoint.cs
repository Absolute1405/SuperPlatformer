using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IPlayer>(out var player))
        {

        }
    }
}
