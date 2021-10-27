using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public abstract class Entity : MonoBehaviour
    {
        protected bool IsDead;
        
        [Header("Stats")]
        [SerializeField] private int health;
        [SerializeField] private int damage;
        
        protected int Health
        {
            get => health;
            private set
            {
                health = value;
                
                if(health <= Variables.HealthToBeDead) IsDead = true;
            }
        }
        
        public void TakeDamage(Entity entity) => Health -= entity.damage;
    }
}