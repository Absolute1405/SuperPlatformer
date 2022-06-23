using System;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryHomework
{
    public class Pool<T> where T: MonoBehaviour
    {
        private List<T> _objects;

        public Pool(T[] objects)
        {
            _objects = new List<T>(objects);
        }

        public T Get()
        {
            foreach (var obj in _objects)
            {
                if (obj.gameObject.activeSelf == false)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }

            throw new InvalidOperationException("no objects in pull");
        }

        public void Push(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}