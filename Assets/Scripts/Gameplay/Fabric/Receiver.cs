using System;
using UnityEngine;

namespace Gameplay.Fabric
{
    public class Receiver : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
