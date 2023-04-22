using UnityEngine;

namespace Gameplay.Common
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speedMovement = 5f;
        
        private Rigidbody _rigidbody;

        public delegate void CollisionDetect(Collision collision);
        public event CollisionDetect OnCollisionDetect;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionDetect?.Invoke(other);
            Destroy(gameObject);
        }

        private void Move()
        {
            _rigidbody.velocity = transform.forward * speedMovement;
        }
    }
}