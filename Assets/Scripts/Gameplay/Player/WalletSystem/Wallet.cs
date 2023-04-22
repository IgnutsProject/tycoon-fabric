using System;
using UnityEngine;

namespace Gameplay.Player.WalletSystem
{
    public class Wallet : Singletone<Wallet>
    {
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
        
        public override void OnAwake()
        {
            Instance = this;
        }

        public bool IsValidPrice(int price)
        {
            return _cashCount - price >= 0;
        }
    }
}