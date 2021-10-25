using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Entity : MonoBehaviour
    {
        protected bool IsDead;
        
        [Header("Stats")]
        [SerializeField] private int health;
        [SerializeField] private int damage;
        
        private int Health
        {
            get => health;
            set
            {
                health = value;
                
                if(health <= Variables.HealthToBeDead) IsDead = true;
            }
        }
        
        public void TakeDamage(Entity entity) => Health -= entity.damage;
    }
}