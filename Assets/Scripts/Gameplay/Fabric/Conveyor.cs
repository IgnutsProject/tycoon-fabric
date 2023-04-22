using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class Conveyor : MonoBehaviour
    {
        [SerializeField] private float conveyorSpeed = 5f;
        
        private readonly List<Product> _productsList = new List<Product>();

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            foreach (var product in _productsList)
            {
                if (product == null)
                {
                    continue;
                }
                product.Move(transform.forward * conveyorSpeed);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent<Product>(out var product) == false) return;
            
            _productsList.Add(product);
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.transform.TryGetComponent<Product>(out var product) == false) return;
            
            _productsList.Remove(product);
        }
    }
}
