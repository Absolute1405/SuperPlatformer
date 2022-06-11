using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AppleGame
{
    public class AppleSpawner : MonoBehaviour
    {
        [SerializeField] private int _appleMaxCount;
        [SerializeField] private Apple _prototype;
        [SerializeField] private Transform _root;
        private ApplePool _pool;
        private void Awake()
        {
            var apples = new Apple[_appleMaxCount];
            for (int i=0; i<_appleMaxCount;i++)
            {
                var apple = Instantiate(_prototype,_root);
                apple.SetActive(false);
                apples[i] = apple;
            }
            _pool = new ApplePool(apples);
             
        }
        private void Start()
        {
            Spawen();
        }
        public Apple Spawen()
        {
            return _pool.Pull();
        }
        public void OnAppleDone(Apple apple)
        {
            _pool.Push(apple);
        }
    }
}