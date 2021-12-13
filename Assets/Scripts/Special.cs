using System;
using UnityEngine;

public class Special : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private int damage = 2;

    private readonly int _layerMask = 1 << 7;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Variables.EnemyTag)) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius, _layerMask);

        foreach (var currentEnemy in colliders)
        {
            currentEnemy.transform.GetComponent<EnemyAI>().TakeDamage(damage);
        }
    }
}
