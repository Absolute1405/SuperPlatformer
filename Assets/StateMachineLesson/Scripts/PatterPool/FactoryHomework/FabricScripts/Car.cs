using UnityEngine;

namespace FactoryHomework
{
    public class Car : MonoBehaviour, IInitializable
    {
        [SerializeField] private SpriteRenderer _renderer;
        private int _speed = 1;

        public void Initialize()
        {
            gameObject.SetActive(false);
        }

        public void OnStart(int speed, float y)
        {
            _speed = speed;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        private void Update()
        {
            transform.Translate(new Vector3( _speed*Time.deltaTime, 0));
        }
    }
}

