using System;
using Gameplay.Common;
using Gameplay.Fabric.ProductLogic;
using UnityEngine;

namespace Gameplay.Fabric.UpgraderLogic
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] private int increasePriceFactor = 3;
        [SerializeField] private TriggerHandler triggerHandler;

        private void Start()
        {
            triggerHandler.OnEnter += other =>
            {
                if (other.TryGetComponent<Product>(out var product) == false) return;

                product.ProductDataSO.Cost += increasePriceFactor;
            };
        }
    }
}