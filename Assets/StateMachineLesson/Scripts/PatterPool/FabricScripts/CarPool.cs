using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FabricGame
{
    public class CarPool : MonoBehaviour
    {
        private List<GameObject> _objects;

        public CarPool(GameObject[] objects)
        {
            foreach (var obj in objects)
            {
                _objects.Add(obj.gameObject);
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