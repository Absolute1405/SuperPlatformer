using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AppleGame
{
    public class Pool
    {
        private List<GameObject> _objects;

        public Pool(GameObject[] objects)
        {
            foreach (var ap in objects)
            {
                _objects.Add(ap.gameObject);
            }

            _objects = new List<GameObject>(objects);
        }

        public GameObject Get()
        {
            foreach (var obj in _objects)
            {
                if (obj.activeSelf == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            throw new InvalidOperationException("no objects in pull");
        }

        public void Push(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}
