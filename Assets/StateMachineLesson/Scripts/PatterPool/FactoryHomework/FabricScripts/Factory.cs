using UnityEngine;

namespace FactoryHomework
{
    public class Factory<T> where T: MonoBehaviour, IInitializable
    {
        private T _prototype;
        private Transform _root;

        public Factory(T prototype, Transform root)
        {
            _prototype = prototype;
            _root = root;
        }

        public T Create()
        {
            var instance = GameObject.Instantiate(_prototype, _root);
            instance.Initialize();

            return instance;
        }
    }
}