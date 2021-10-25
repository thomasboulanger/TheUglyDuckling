using UnityEngine;

namespace Scenes.Jordan.Scripts
{
    public class BossManager : EnemyManager
    {
        [SerializeField] private int numberOfAttacks = 2;
        
        protected override void RandomAction()
        {
            //select btw attacks animations
            var randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NumberOfActions + numberOfAttacks - 1);

            /*if (randomIndex == Variables.FirstActionIndex) Attack();
            else Dodge();*/
        }
        
        private void Attack()
        {
            UpdateCounters(true);
            
            IsActive = true;

            for (var i = 1; i < numberOfAttacks + 1; i++)
            {
                Animator.Play(name + Variables.AttackAnimName + i);
            }
            Animator.Play(Variables.AttackAnimName);
            Damage(Player);
        }
    }
}