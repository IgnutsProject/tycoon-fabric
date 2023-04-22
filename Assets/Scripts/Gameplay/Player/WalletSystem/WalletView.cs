using Common;
using Gameplay.Fabric.CashRegisterLogic;
using TMPro;
using UnityEngine;

namespace Gameplay.Player.WalletSystem
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private Wallet wallet;
        [SerializeField] private TextMeshProUGUI cashText;

        private void Start()
        {
            wallet.OnCashChanged += cash =>
            {
                UpdateUI();
            };

            UpdateUI();
        }

        private void UpdateUI()
        {
            cashText.text = $"Wallet: {wallet.CashCount}{GameConfig.GameWalletSign}";
        }
    }
}