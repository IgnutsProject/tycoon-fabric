using System;
using System.Collections.Generic;
using Gameplay.Fabric.ProductLogic;
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
                product.Move(transform.forward * conveyorSpeed);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent<Product>(out var product) == false) return;

            product.OnSell += () =>
            {
                _productsList.Remove(product);
            };
            
            _productsList.Add(product);
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.transform.TryGetComponent<Product>(out var product) == false) return;
            
            _productsList.Remove(product);
        }
    }
}
