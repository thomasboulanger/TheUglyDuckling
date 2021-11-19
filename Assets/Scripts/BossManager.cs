using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public abstract class BossManager : EnemyAI
    {
        [SerializeField] protected int nbAttacks = 2;

        protected override void RandomAction()
        {
            var randomIndex = Random.Range(1, Variables.NbActions + nbAttacks);

            RandomAttack(randomIndex);
        }

        protected void RandomAttack(int randomIndex)
        {
            for (var i = 1; i <= nbAttacks; i++)
            {
                if (randomIndex != i) continue;
                
                Attack(randomIndex);
                return;
            }
        }
        
        protected override void Attack()
        {
            var randomIndex = Random.Range(Variables.FirstAttackIndex, nbAttacks + 1);
            
            Attack(randomIndex);
        }

        protected void Reload()
        {
            ResetCounters();
            animator.Play(Variables.ReloadAnimName);
        }
        
        protected void Rest()
        {
            ResetCounters();
            animator.Play(Variables.RestAnimName);
        }
        
        private void Attack(int attackIndex)
        {
            UpdateCounters(true);
            
            isActive = true;
            
            animator.Play(Variables.AttackAnimName + attackIndex);
        }
    }
}