using UnityEngine;
using Random = System.Random;

namespace Scenes.Jordan.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public float fireRate;

        [SerializeField] 
        private int distance = 20;
        [SerializeField] 
        private float speed = 20f;
        [SerializeField] 
        private GameObject bullet;
        [SerializeField] 
        private bool isPlayer;
        private Quaternion _bulletRotation;

        private void Start()
        {
            if (transform.parent.CompareTag("Riffle"))
            {
                fireRate = .18f;
            }
            else if (transform.parent.CompareTag("Shotgun"))
            {
                fireRate = .8f;
            }
            else if (transform.parent.CompareTag("Laser"))
            {
                fireRate = 1.5f;
            }
        }

        public void Shoot()
        {
            if (!isPlayer) _bulletRotation = Quaternion.Euler(0f, 0f, 180f+UnityEngine.Random.Range(-2f,8f));
            else _bulletRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-2f,8f));
            
            var currentBullet = Instantiate(bullet, transform.position, _bulletRotation).GetComponent<Bullet>();
            currentBullet.Initialize(speed, distance, isPlayer);
        }
    }
}