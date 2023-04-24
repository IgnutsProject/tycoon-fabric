using System;
using Common;
using TMPro;
using UnityEngine;

namespace Gameplay.Fabric.ShopLogic
{
    public class ShoppingSlotView : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private ShoppingSlot shoppingSlot;
        
        [Header("UI")]
        [SerializeField] private TextMeshPro priceText;
        [SerializeField] private TextMeshPro nameText;

        [Header("Audio")] 
        [SerializeField] private AudioSource audioSource;
        
        private void Start()
        {
            priceText.text = $"{shoppingSlot.Price}{GameConfig.GameWalletSign}";
            nameText.text = shoppingSlot.SlotName;

            shoppingSlot.OnBuy += () =>
            {
                if (audioSource == false) return;
                
                Instantiate(audioSource, audioSource.transform.position, audioSource.transform.rotation).Play();
            };
        }
    }
}