using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public abstract class Entity : MonoBehaviour
    {
        protected bool IsDead;
        
        [SerializeField] private int health;

        protected int Health
        {
            get => health;
            private set
            {
                health = value;
                
                if(health <= Variables.HealthToBeDead) IsDead = true;
            }
        }
        
        public void TakeDamage(int damage) => Health -= damage;
    }
}