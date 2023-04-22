using System;
using Common;
using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Fabric.ProductLogic
{
    [CreateAssetMenu(fileName = "Product 1", menuName = "ScriptableObjects/Product", order = 0)]
    public class ProductDataSO : DataSO
    {
        [SerializeField] private int cost = 1;
        
        public int Cost
        {
            get => cost;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Cost lower then zero");
                }
                
                cost = value;
            }
        }
    }
}