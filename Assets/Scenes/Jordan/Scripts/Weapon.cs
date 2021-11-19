using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int distance = 5;
        [SerializeField] private float speed = 20f;
        
        [SerializeField] private GameObject bullet;

        [SerializeField] private bool isPlayer;

        private Quaternion _bulletRotation;

        private void Update()
        {
           if (isPlayer && InputManager.upInput) Shoot();
        }

        public void Shoot()
        {
            if (!isPlayer) _bulletRotation = Quaternion.Euler(0, 180f, 0f);
            
            var currentBullet = Instantiate(bullet, transform.position, _bulletRotation, transform).GetComponent<Bullet>();
            currentBullet.Initialize(speed, distance, isPlayer);
        }
    }
}