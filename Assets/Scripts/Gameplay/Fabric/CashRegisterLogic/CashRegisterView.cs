using System;
using Common;
using Gameplay.Fabric.ProductLogic;
using TMPro;
using UnityEngine;

namespace Gameplay.Fabric.CashRegisterLogic
{
    public class CashRegisterView : MonoBehaviour
    {
        [SerializeField] private CashRegister cashRegister;
        [SerializeField] private TextMeshPro cashText;

        private void Start()
        {
            cashRegister.OnCashChanged += cash =>
            {
                UpdateUI();
            };

            UpdateUI();
        }

        private void UpdateUI()
        {
            cashText.text = $"{cashRegister.CashCount}{GameConfig.GameWalletSign}";
        }
    }
}