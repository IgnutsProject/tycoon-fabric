using System.Collections;
using Common;
using Gameplay.Common;
using Gameplay.Player.Common;
using TMPro;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput Instance { get; private set; }

        [SerializeField] private float lookDistance = 2f;
        
        public delegate void Move(Vector3 direction);
        public event Move OnMove;
        
        public delegate void FinishMove();
        public event FinishMove OnFinishMove;

        public delegate void StartAttack();
        public event StartAttack OnStartAttack;
        
        public delegate void EndAttack();
        public event EndAttack OnEndAttack;

        public delegate void Reload();
        public event Reload OnReload;

        public delegate void MouseWheelUp();
        public event MouseWheelUp OnMouseWheelUp;

        public delegate void MouseWheelDown();
        public event MouseWheelDown OnMouseWheelDown;
        
        public delegate void Use();
        public event Use OnUse;

        public delegate void LookAt();
        public event LookAt OnLookAt;
        
        public delegate void UnLookAt();
        public event UnLookAt OnUnLookAt;

        public delegate void Pause();
        public event Pause OnPause;

        private ILookAt _lastObjectLooked;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            if (moveX != 0 || moveZ != 0)
            {
                Vector3 direction = transform.forward * moveZ + transform.right * moveX;
                OnMove?.Invoke(direction);
            }
            else
            {
                OnFinishMove?.Invoke();
            }

            if (mouseWheel > 0)
            {
                OnMouseWheelUp?.Invoke();
            }
            else if (mouseWheel < 0)
            {
                OnMouseWheelDown?.Invoke();
            }

            if (Input.GetKeyDown(InputConfig.AttackKey))
            {
                OnStartAttack?.Invoke();
            }

            if (Input.GetKeyUp(InputConfig.AttackKey))
            {
                OnEndAttack?.Invoke();
            }

            if (Input.GetKeyDown(InputConfig.ReloadKey))
            {
                OnReload?.Invoke();
            }

            if (Input.GetKeyDown(InputConfig.UseKey))
            {
                OnUse?.Invoke();
            }

            if (Input.GetKeyDown(InputConfig.PauseKey))
            {
                OnPause?.Invoke();
            }
            
            
            LookForward();
        }

        private void LookForward()
        {
            if (Camera.main is null) return;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, lookDistance))
            {
                if (_lastObjectLooked != null)  OnUnLookAt?.Invoke();
                return;
            }

            if (hit.transform.TryGetComponent<ILookAt>(out var objectLook) == false)
            {
                _lastObjectLooked?.UnLookAt();
                _lastObjectLooked = null;
                OnUnLookAt?.Invoke();
                return;
            }

            if (_lastObjectLooked != null) return;
            
            objectLook.LookAt();
            _lastObjectLooked = objectLook;
            OnLookAt?.Invoke();
        }
    }
}
