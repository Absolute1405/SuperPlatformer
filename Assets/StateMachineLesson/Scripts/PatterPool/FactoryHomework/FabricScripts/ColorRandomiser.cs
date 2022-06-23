using UnityEngine;

namespace FactoryHomework
{
    public static class ColorRandomiser
    {
        public static Color GetRandomColor()
        {
            var r = Random.Range(0, 255);
            var g = Random.Range(0, 255);
            var b = Random.Range(0, 255);

            return new Color(r, g, b);
        }
    }
}

