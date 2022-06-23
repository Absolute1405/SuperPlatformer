using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FabricGame
{
    public class Car : MonoBehaviour
    {
        private int _speed = 1;
        [SerializeField] private int _maxCount = 1;
        [SerializeField] private CarFabric _factory;

        private CarPool _pool;

        public void Initialize()
        {
            _speed=Random.Range(1,5);
            Debug.Log(_speed);
        }
        private void Start()
        {
            Initialize();
        }
        private void Update()
        {
            transform.Translate(new Vector3( _speed*Time.deltaTime, 0));
        }
        private void CreatePool()
        {
            var cars = new GameObject[_maxCount];

            for (int i = 0; i < _maxCount; i++)
            {
                cars[i] = _factory.Create().gameObject;
            }

            _pool = new CarPool(cars);
        }
    }
}

