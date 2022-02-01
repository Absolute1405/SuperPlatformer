using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cutscene : MonoBehaviour
{
    protected Vector3[] points;
    protected float[] pause;

    protected abstract IEnumerable LifeCycle();
}
