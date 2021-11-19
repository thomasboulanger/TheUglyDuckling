using System;
using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int weaponDamage;

        private int _distance = 2;
        private bool _isPlayer;

        private Rigidbody2D _rigidbody;

        private Vector3 _startPos;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _startPos = transform.position;
        }

        private void Update()
        {
            CheckBulletOutOfRange();
        }

        private void CheckBulletOutOfRange()
        {
            if(Vector3.Distance(_startPos, transform.position) >= _distance) Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (_isPlayer)
            {
                case true when other.gameObject.CompareTag("Enemy"):
                case false when other.gameObject.CompareTag("Player"):
                    other.GetComponent<Entity>().TakeDamage(weaponDamage);
                    Destroy(gameObject);
                    break;
            }
        }

        public void Initialize(float speed, int distance, bool isPlayer)
        {
            _distance = distance;
            _isPlayer = isPlayer;
        
            _rigidbody.velocity = transform.right * speed;
        }
    }
}
