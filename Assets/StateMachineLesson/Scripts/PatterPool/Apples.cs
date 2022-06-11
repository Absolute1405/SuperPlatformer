using System;
using UnityEngine;

namespace AppleGame
{
    public class Apples : MonoBehaviour
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private AppleFactory _factory;

        private Pool _pool;

        private void Awake()
        {
            CreatePool();
        }

        public Apple Spawn()
        {
            var obj = _pool.Get();
            var apple = obj.GetComponent<Apple>();

            if (apple == null)
                throw new InvalidOperationException();

            apple.Disposed += OnAppleDone;
            apple.OnSpawn();

            return apple;
        }

        private void OnAppleDone(Apple apple)
        {
            apple.Disposed -= OnAppleDone;
            _pool.Push(apple.gameObject);
        }

        private void CreatePool()
        {
            var apples = new GameObject[_maxCount];

            for (int i = 0; i < _maxCount; i++)
            {
                apples[i] = _factory.Create().gameObject;
            }

            _pool = new Pool(apples);
        }
    }
}