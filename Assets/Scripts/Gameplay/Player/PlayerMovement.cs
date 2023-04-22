using System;
using Gameplay.Player;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Instance { get; private set; }
        
        [SerializeField] private float movementSpeed =1;
        [SerializeField] private float gravity = 9.8f;
    
        private float _velocity = 0;
        private CharacterController _characterController;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            
            PlayerInput.Instance.OnMove += Move;
        }

        private void FixedUpdate()
        {
            CalculateGravity();
        }

        private void Move(Vector3 direction)
        {
            _characterController.Move(direction * Time.deltaTime * movementSpeed);
        }

        private void CalculateGravity()
        {
            if(_characterController.isGrounded)
            {
                _velocity = 0;
            }
            else
            {
                _velocity -= gravity * Time.deltaTime;
                _characterController.Move(new Vector3(0, _velocity, 0));
            }
        }

    }
}
