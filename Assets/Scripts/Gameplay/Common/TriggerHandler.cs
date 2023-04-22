using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Common
{
    public class TriggerHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Collider> onEnter;

        public event UnityAction<Collider> OnEnter
        {
            add => onEnter.AddListener(value);
            remove => onEnter.RemoveListener(value);
        }

        private void OnTriggerEnter(Collider other)
        {
            onEnter?.Invoke(other);
        }
    }
}
