using System;
using Player;
using UnityEngine;

namespace Gameplay.UI
{
    public class BillboardUI : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(PlayerMovement.Instance.transform);
        }
    }
}