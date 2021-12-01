using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    
    [SerializeField] private int distance = 20;
    [SerializeField] private float speed = 20f;
    [SerializeField] private bool isPlayer;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject grenade;
    
    private Quaternion _bulletRotation;

    //firerate riffle 0.18f, shotgun 0.1f, laser 1.5f
    private void Update()
    {
        if(isPlayer && InputManager.testInput) SpecialAttack();
    }

    public void Shoot()
    {
        _bulletRotation = !isPlayer ? Quaternion.Euler(0f, 0f, 180f + Random.Range(-2f,6f)) : Quaternion.Euler(0f, 0f, Random.Range(-2f,6f));
            
        var currentBullet = Instantiate(bullet, transform.position, _bulletRotation).GetComponent<Bullet>();
        currentBullet.Initialize(speed, distance, isPlayer);
    }

    public void SpecialAttack()
    {
        var currentGrenade = Instantiate(grenade, transform.position,  quaternion.identity).GetComponent<Rigidbody2D>();
        currentGrenade.AddForce(grenade.transform.right * 15f, ForceMode2D.Impulse);

        BeatManager.feverStacks = 0;
    }
}