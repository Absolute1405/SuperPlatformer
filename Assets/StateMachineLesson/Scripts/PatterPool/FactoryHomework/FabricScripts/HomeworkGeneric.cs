using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkGeneric<T> where T : MonoBehaviour
{
    private List<T> _objects;

    public HomeworkGeneric()
    {
        _objects = new List<T>();
    }

    public void Push(T[] objects)
    {
        _objects.AddRange(objects);
    }

    public void Push(T instance)
    {
        _objects.Add(instance);
    }

    public T Pop(int index)
    {
        if (index > _objects.Count || index < 0)
            throw new ArgumentOutOfRangeException();

        return _objects[index];
    }
}
