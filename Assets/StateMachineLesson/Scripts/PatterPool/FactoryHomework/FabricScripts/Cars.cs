using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FactoryHomework
{
    public class Cars : MonoBehaviour
    {
        [SerializeField] private Car _prototype;
        [SerializeField, Min(1)] private int _maxCount = 10;
        private Factory<Car> _factory;
        [SerializeField] private int _minYposition = -4;
        [SerializeField] private int _maxYposition = 4;

        private Pool<Car> _pool;

        public void Initialize()
        {
            _factory = new Factory<Car>(_prototype, transform);
            CreatePool();
        }

        private void CreatePool()
        {
            var cars = new Car[_maxCount];

            for (int i = 0; i < _maxCount; i++)
            {
                var color = ColorRandomiser.GetRandomColor();
                cars[i] = _factory.Create();
            }

            _pool = new Pool<Car>(cars);
             
        }
        

        public void Spawn()
        {
            var speed = Random.Range(1, 5);
            var positionYCar = Random.Range(_minYposition, _maxYposition);

            var car = _pool.Get();
            car.OnStart(speed, positionYCar);
        }
    }
}

