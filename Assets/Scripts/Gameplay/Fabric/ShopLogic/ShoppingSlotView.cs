using System;
using Common;
using TMPro;
using UnityEngine;

namespace Gameplay.Fabric.ShopLogic
{
    public class ShoppingSlotView : MonoBehaviour
    {
        [SerializeField] private ShoppingSlot shoppingSlot;
        [SerializeField] private TextMeshPro priceText;
        [SerializeField] private TextMeshPro nameText;

        private void Start()
        {
            priceText.text = $"{shoppingSlot.Price}{GameConfig.GameWalletSign}";
            nameText.text = shoppingSlot.SlotName;
        }
    }
}