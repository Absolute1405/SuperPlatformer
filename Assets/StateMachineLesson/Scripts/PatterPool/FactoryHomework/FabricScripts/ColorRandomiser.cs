using UnityEngine;

namespace FactoryHomework
{
    public static class ColorRandomiser
    {
        public static Color GetRandomColor()
        {
            var r = Random.Range(0f, 255f);
            var g = Random.Range(0f, 255f);
            var b = Random.Range(0f, 255f);
            
            return new Color(r, g, b);
        }
    }
}

