using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppleGame
{
    public class AppleFactory : MonoBehaviour
    {
        [SerializeField] private Apple _prototype;
        [SerializeField] private Transform _root;

        public Apple Create()
        {
            var apple = Instantiate(_prototype, _root);
            apple.Initialize();

            return apple;
        }
    }
}

