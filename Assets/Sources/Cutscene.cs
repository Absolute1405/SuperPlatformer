using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cutscene : MonoBehaviour
{
    protected Vector2[] points;

    protected abstract IEnumerable LifeCycle();
}
