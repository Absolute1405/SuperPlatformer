using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryHomework
{
    public class CarTest : MonoBehaviour
    {
        [SerializeField] private Cars _cars;

        private void Awake()
        {
            _cars.Initialize();
        }

        private void Start()
        {
            _cars.Spawn();
            _cars.Spawn();
            _cars.Spawn();
        }
    }
}

