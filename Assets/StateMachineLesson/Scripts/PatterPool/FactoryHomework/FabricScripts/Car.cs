using UnityEngine;
using System;

namespace FactoryHomework
{
    public class Car : MonoBehaviour, IInitializable<CarArgs>
    {
        [SerializeField] private SpriteRenderer _renderer;
        private int _speed = 1;
        public event Action<Car> OnColisionFinish;

        public void Initialize(CarArgs args)
        {
            gameObject.SetActive(false);
            _renderer.color = args.Color;
        }

        public void OnStart(int speed, float x, float y)
        {
            _speed = speed;
            transform.position = new Vector3(x, y, transform.position.z);
        }

        private void Update()
        {
            transform.Translate(new Vector3( _speed*Time.deltaTime, 0));
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Finish>(out var finish))
            {
                OnColisionFinish?.Invoke(this);
            }
        }
    }

    public class CarArgs
    {
        public CarArgs(Color color)
        {
            Color = color;
        }

        public Color Color { get; }
    }
    
}

