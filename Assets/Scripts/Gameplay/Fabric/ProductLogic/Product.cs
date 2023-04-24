using System;
using UnityEngine;

namespace Gameplay.Fabric.ProductLogic
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private ProductDataSO productDataSO;
        
        private Rigidbody _rigidbody;

        public ProductDataSO ProductDataSO => productDataSO;

        public event Action OnSell;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            productDataSO = Instantiate(productDataSO);
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.velocity = direction;
        }

        public void Sell()
        {
            OnSell?.Invoke();
            
            Destroy(gameObject);
        }
    }
}