using UnityEngine;

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
        
        //Reload();
    }
    
    
    
    /*protected override void Attack(int randomIndex)
    {
        //var randomIndex = Random.Range(Variables.FirstAttackIndex, nbAttacks + 1);
            
        Attack(randomIndex);
    }*/
    
    protected void Rest()
    {
        ResetCounters();
        animator.Play(Variables.RestAnimName);
    }
        
    protected void Attack(int attackIndex)
    {
        UpdateCounters(true);
            
        isActive = true;
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
        
        animator.Play(Variables.AttackAnimName + attackIndex);

        weapon.Shoot();
    }
}