using UnityEngine;

namespace _Game_.Scripts.Other
{
    public static class Extensions
    {
        public static Vector3 GetRandomVector()
        {
            var randomX = Random.Range(-180f, 180f);
            var randomY = Random.Range(-180f, 180f);
            var randomZ = Random.Range(-180f, 180f);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
}