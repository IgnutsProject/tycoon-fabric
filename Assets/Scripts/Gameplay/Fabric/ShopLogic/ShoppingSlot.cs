using System;
using Gameplay.Common;
using Gameplay.Player.WalletSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Fabric.ShopLogic
{
    public class ShoppingSlot : MonoBehaviour
    {
        [Header("Properties")] 
        [SerializeField] private string slotName = "Dropper";
        [SerializeField] private int price = 10;
        [SerializeField] private TriggerHandler triggerHandler;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onBuy;

        public int Price => price;
        public string SlotName => slotName;
        
        public event UnityAction OnBuy
        {
            add => onBuy.AddListener(value);
            remove => onBuy.RemoveListener(value);
        }

        private void Start()
        {
            triggerHandler.OnEnter += col =>
            {
                Debug.Log(Wallet.Instance.IsValidPrice(price));
                Buy();
            };
        }

        private void Buy()
        {
            if (Wallet.Instance.IsValidPrice(price) == false) return;
            
            Wallet.Instance.CashCount -= price;
            
            onBuy?.Invoke();
            Destroy(gameObject);
        }
    }
}