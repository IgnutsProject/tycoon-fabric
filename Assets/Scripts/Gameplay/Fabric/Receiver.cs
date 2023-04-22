using System;
using Common;
using Gameplay.Common;
using Gameplay.Fabric.ProductLogic;
using UnityEngine;

namespace Gameplay.Fabric
{
    public class Receiver : MonoBehaviour
    {
        [SerializeField] private TriggerHandler triggerHandler;

        public event Action<ProductDataSO> OnProductSell;

        private void Start()
        {
            triggerHandler.OnEnter += other =>
            {
                if (other.TryGetComponent<Product>(out var product) == false) return;
            
                StartCoroutine(Utils.MakeActionDelay(GameConfig.ReceiverSellProductTime, () =>
                {
                    OnProductSell?.Invoke(product.ProductDataSO);
                    
                    product.Sell();
                }));
            };
        }
    }
}
