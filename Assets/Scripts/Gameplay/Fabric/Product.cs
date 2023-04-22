using System;
using UnityEngine;

namespace Gameplay
{
    public class Product : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            //_rigidbody.AddForce(direction, ForceMode.Acceleration);
            _rigidbody.velocity = direction;
        }
    }
}