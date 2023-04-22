using System;
using Player;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera Instance { get; private set; }

        [SerializeField] private float horizontalSpeed = 1f;
        [SerializeField] private float verticalSpeed = 1f;
        
        private Camera _cam;
        
        public float XRotation { get; set;}
        public float YRotation { get; set;}

        private Vector3 TargetCameraRotation => new Vector3(XRotation, _cam.transform.eulerAngles.y, 0.0f);
        private Vector3 TargetPlayerRotation => new Vector3(0, YRotation, 0);

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
            _cam = Camera.main;

            Cursor.lockState = CursorLockMode.Locked;
        }
 
        private void LateUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
 
            YRotation += mouseX;
            XRotation -= mouseY;
            
            XRotation = Mathf.Clamp(XRotation, -90, 90);

            _cam.transform.eulerAngles = TargetCameraRotation;
            transform.eulerAngles = TargetPlayerRotation;
        }
    }
}
