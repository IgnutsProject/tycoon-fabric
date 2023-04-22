using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Common
{
    public class Health : MonoBehaviour
    {
        [Header("General properties")] 
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float defaultHealth = 100f;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onDecrease;
        [SerializeField] private UnityEvent onIncrease;
        [SerializeField] private UnityEvent onZeroHealth;

        private float _health = 0;

        public float DefaultHealth => defaultHealth;

        public event UnityAction OnDecrease
        {
            add => onDecrease.AddListener(value);
            remove => onDecrease.RemoveListener(value);
        }
        
        public event UnityAction OnIncrease
        {
            add => onIncrease.AddListener(value);
            remove => onIncrease.RemoveListener(value);
        }
        
        public event UnityAction OnZeroHealth
        {
            add => onZeroHealth.AddListener(value);
            remove => onZeroHealth.RemoveListener(value);
        }

        public delegate void HealthChange(float health);
        public event HealthChange OnHealthChange;
        
        public float HealthValue
        {
            get => _health;
            set
            {
                var lastValue = _health;
                _health = value;
                
                if (lastValue > value)
                {
                    onDecrease.Invoke();
                    if (_health <= 0)
                    {
                        onZeroHealth.Invoke();
                        _health = 0;
                    }
                }
                if (lastValue < value)
                {
                    onIncrease.Invoke();
                    if (_health > maxHealth)
                    {
                        _health = maxHealth;
                    }
                }
                
                OnHealthChange?.Invoke(_health);
            }
        }
        
        private void Start()
        {
            HealthValue = defaultHealth;
        }
    }
}
