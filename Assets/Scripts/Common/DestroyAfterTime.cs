using System;
using Common;
using UnityEngine;

namespace Gameplay.Common
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float time = 5;

        private void Start()
        {
            StartCoroutine(Utils.MakeActionDelay(delegate
            {
                Destroy(gameObject);
            }, time));
        }
    }
}