using UnityEngine;

public abstract class BossManager : EnemyAI
{
    protected void Rest()
    {
        ResetCounters();
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.RestAnimName);
    }
        
    protected void Attack(int attackIndex, int nbBullet)
    {
        UpdateCounters(true);
            
        IsActive = true;
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.AttackAnimName + attackIndex);

        Weapon.Shoot(nbBullet);
    }
    
    protected virtual void RandomAction()
    {
       
    }
}