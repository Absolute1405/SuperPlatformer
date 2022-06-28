using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworckJeneric<T> where T : MonoBehaviour
{
    private List<T> _objects;

    public void Push(T[] objects)
    {
        _objects = new List<T>(objects);
    }
}
