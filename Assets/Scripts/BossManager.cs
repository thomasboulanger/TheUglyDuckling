using UnityEngine;

public abstract class BossManager : EnemyAI
{
    [SerializeField] protected int nbAttacks = 2;
    
    protected void Rest()
    {
        ResetCounters();
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.RestAnimName);
    }
        
    protected void Attack(int attackIndex)
    {
        UpdateCounters(true);
            
        IsActive = true;
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
        
        Animator.Play(Variables.AttackAnimName + attackIndex);

        Weapon.Shoot();
    }
    
    protected virtual void RandomAction()
    {
       
    }
}