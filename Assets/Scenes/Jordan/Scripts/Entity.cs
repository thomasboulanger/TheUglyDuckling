using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class Entity : MonoBehaviour
    {
        private bool _isDead;
        
        [Header("Stats")]
        [SerializeField] private int health;
        [SerializeField] private int damage;
        
        private bool IsDead
        {
            set
            {
                _isDead = value;
                
                if(_isDead && !gameObject.CompareTag(Variables.PlayerTag)) Destroy(gameObject);
            }
        }
        
        private int Health
        {
            get => health;
            set
            {
                health = value;
                
                if(health <= Variables.HealthToBeDead) IsDead = true;
            }
        }
        
        protected void Damage(Entity entity) => entity.Health -= damage;
    }
}