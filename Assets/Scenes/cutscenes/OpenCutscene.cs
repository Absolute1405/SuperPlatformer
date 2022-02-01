using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCutscene : Cutscene
{
    [SerializeField] private float speed = 1f;
    private Vector3 vector3 ;
    protected override IEnumerable LifeCycle()
    {
        foreach(Vector3 point in points)
        {
            vector3 = new Vector2(transform.position.x, transform.position.y);
            Vector2 point_vctor = new Vector2(point.x, point.y);
            vector3 = Vector3.Lerp(vector3, point, Time.deltaTime * speed);
        }

        yield return null;
    }
}
