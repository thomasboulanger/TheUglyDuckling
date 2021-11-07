using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int weaponDamage;
        [SerializeField] private float speed = 20f;
        [SerializeField] private int distance = 2;

        private Rigidbody _rigidbody;

        private Vector3 _startPos;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.right * speed;

            _startPos = transform.position;
        }

        private void Update()
        {
            CheckBulletOutOfRange();
        }

        private void CheckBulletOutOfRange()
        {
            if(Vector3.Distance(_startPos, transform.position) >= distance) Destroy(gameObject);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Variables.EnemyTag) || other.CompareTag(Variables.PlayerTag)) 
                other.GetComponent<Entity>().TakeDamage(weaponDamage);
            
            Destroy(gameObject);
        }
    }
}
