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
    
    public void Shoot()
    {
        _bulletRotation = !isPlayer ? Quaternion.Euler(0f, 0f, 180f + Random.Range(-2f,6f)) : Quaternion.Euler(0f, 0f, Random.Range(-2f,6f));
            
        var currentBullet = Instantiate(bullet, transform.position, _bulletRotation).GetComponent<Bullet>();
        currentBullet.Initialize(speed, distance, isPlayer);
    }
    
    public void Shoot(int nbBullet)
    {
        for (int i = 0; i < nbBullet; i++)
        {
            Invoke(nameof(Shoot), i * 0.15f);
        }
    }

    public void SpecialAttack()
    {
        var currentGrenade = Instantiate(grenade, transform.position,  quaternion.identity).GetComponent<Rigidbody2D>();
        currentGrenade.AddForce(grenade.transform.right * 15f, ForceMode2D.Impulse);
        Destroy(currentGrenade.transform.gameObject, 5f);

        BeatManager.feverStacks = 0;
    }
}