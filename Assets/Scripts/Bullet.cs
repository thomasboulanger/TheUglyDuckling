using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int weaponDamage;
    [SerializeField] private GameObject _particle;

    
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
        if (other.transform.CompareTag("Enemy") || other.transform.CompareTag("Player"))
        {
            GameObject go = Instantiate(_particle, transform.position, quaternion.identity);
            Destroy(go.gameObject,.4f);
        }
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