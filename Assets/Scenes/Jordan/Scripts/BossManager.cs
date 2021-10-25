using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class BossManager : EnemyManager
    {
        [SerializeField] private int numberOfAttacks = 2;
        
        protected override void RandomAction()
        {
            var randomIndex = Random.Range(1, Variables.NumberOfActions + numberOfAttacks);

            for (var i = 1; i <= numberOfAttacks; i++)
            {
                if (randomIndex != i) continue;
                
                Attack(randomIndex);
                return;
            }

            Dodge();
        }

        protected override void Attack()
        {
            var randomIndex = Random.Range(Variables.FirstAttackIndex, numberOfAttacks + 1);
            
            Attack(randomIndex);
        }

        private void Attack(int attackIndex)
        {
            UpdateCounters(true);
            
            IsActive = true;
            
            Animator.Play(name + Variables.AttackAnimName + attackIndex);
        }
    }
}