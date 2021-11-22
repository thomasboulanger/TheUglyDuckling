using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected bool isDead;
        
    [SerializeField] private int health;

    public int Health
    {
        get => health;
        private set
        {
            health = value;
                
            if(health <= Variables.HealthToBeDead) isDead = true;
        }
    }
        
    public void TakeDamage(int damage) => Health -= damage;
}