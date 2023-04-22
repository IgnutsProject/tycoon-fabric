using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common
{
    [Serializable]
    public struct FloatRange
    {
        [Header("Min value")]
        [Range(float.MinValue, float.MaxValue)]
        [SerializeField] private float min;

        [Header("Max value")]
        [Range(float.MinValue, float.MaxValue)] 
        [SerializeField] private float max;

        public float GetRandomValue()
        {
            return Random.Range(min, max);
        }
    }
}