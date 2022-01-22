using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCutscene : Cutscene
{
    [SerializeField] private float speed = 1f;
    private Vector2 vector2 ;
    protected override IEnumerable LifeCycle()
    {
        foreach(Vector2 point in points)
        {
        //    vector2 = new Vector2(transform.position.x, transform.position.y);
        //    Vector2 point_vctor = new Vector2(point.x, point.y);
        //    vector2 = vector2.MoveTowards(vector2,point_vctor,speed*Time.deltaTime)
        }

        yield return null;
    }
}
