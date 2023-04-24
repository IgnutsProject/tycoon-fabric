using System;
using Common;
using Gameplay.Fabric.ProductLogic;
using TMPro;
using UnityEngine;

namespace Gameplay.Fabric.CashRegisterLogic
{
    public class CashRegisterView : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private CashRegister cashRegister;
        
        [Header("UI")]
        [SerializeField] private TextMeshPro cashText;

        [Header("Audio")] 
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            cashRegister.OnCashChanged += cash =>
            {
                UpdateUI();
            };

            cashRegister.OnCashCheckOut += () =>
            {
                if (audioSource == false) return;
                
                audioSource.Play();
            };

            UpdateUI();
        }

        private void UpdateUI()
        {
            cashText.text = $"{cashRegister.CashCount}{GameConfig.GameWalletSign}";
        }
    }
}