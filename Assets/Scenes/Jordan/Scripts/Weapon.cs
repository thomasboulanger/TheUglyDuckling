using System;
using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [Header("Bullets")]
        [SerializeField] private GameObject assaultRiffleBullet;
        [SerializeField] private GameObject shotgunBullet;
        [SerializeField] private GameObject laserBullet;
        
        [Space(20)]
        [SerializeField] private WeaponType weaponType;
        
        [SerializeField] private bool isPlayer;

        private GameObject _bullet;
        
        private Quaternion _bulletRotation;
        
        private enum WeaponType
        {
            AssaultRiffle,
            Shotgun,
            Laser
        }

        private void Awake()
        {
            _bullet = weaponType switch
            {
                WeaponType.AssaultRiffle => assaultRiffleBullet,
                WeaponType.Shotgun => shotgunBullet,
                WeaponType.Laser => laserBullet,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void Update()
        {
            //if (isPlayer && Input.GetKeyDown(KeyCode.Space)) Shoot();
        }

        public void Shoot()
        {
            if (!isPlayer) _bulletRotation = Quaternion.Euler(0, 180f, 0f);

            Instantiate(_bullet, transform.position, _bulletRotation, transform);
        }
    }
}