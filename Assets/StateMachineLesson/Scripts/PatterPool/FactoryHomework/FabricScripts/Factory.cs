using UnityEngine;

namespace FactoryHomework
{
    public class Factory<T, V> where T : MonoBehaviour, IInitializable<V>
    {
        private T _prototype;
        private Transform _root;

        public Factory(T prototype, Transform root)
        {
            _prototype = prototype;
            _root = root;
        }

        public T Create(V args)
        {
            var instance = GameObject.Instantiate(_prototype, _root);
            instance.Initialize(args);

            return instance;
        }
    }
}