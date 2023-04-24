using System;
using Gameplay.Common;
using Gameplay.Player.WalletSystem;
using Player;
using UnityEngine;

namespace Gameplay.Fabric.CashRegisterLogic
{
    public class CashRegister : MonoBehaviour
    {
        [Header("Receiver")] 
        [SerializeField] private Receiver receiver;

        [Header("Cash out trigger")] 
        [SerializeField] private TriggerHandler cashOutTrigger;

        private int _cashCount;
        
        public int CashCount
        {
            get => _cashCount;
            set
            {
                _cashCount = value;
                
                OnCashChanged?.Invoke(_cashCount);
            }
        }

        public event Action<int> OnCashChanged;
        public event Action OnCashCheckOut;

        private void Start()
        {
            receiver.OnProductSell += data =>
            {
                CashCount += data.Cost;
            };

            cashOutTrigger.OnEnter += col =>
            {
                if (col.GetComponent<PlayerMovement>() == false) return;

                Wallet.Instance.CashCount += CashCount;
                
                CashCount = 0;
                
                OnCashCheckOut?.Invoke();
            };
        }
    }
}