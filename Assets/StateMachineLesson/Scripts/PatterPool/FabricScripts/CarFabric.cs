using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FabricGame
{
    public class CarFabric : MonoBehaviour
    {
        [SerializeField] private Car _prototype;
        [SerializeField] private Transform _root;
        const int minYposition = -4;
        const int maxYposition = 4;
        public Car Create()
        {
            var positionYCar = Random.Range(maxYposition, -minYposition);
            var car = Instantiate(_prototype, _root);
            car.Initialize();

            return car;
        }
    }
}