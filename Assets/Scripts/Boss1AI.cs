using UnityEngine;

public class Boss1AI : BossManager
{
    protected override void EnemyActions()
    {
        if (isActive) return;

        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (actionCount == 0)
        {
            //randomIndex = Random.Range(Variables.FirstActionIndex, Variables.NbActions);
            
            cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
            
            //if(dodgeCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
            if(attackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;

        if (actionCount != 4) return;
        
        if(attackCount == maxActionRepetition) Reload();
        else Attack();
        
        actionCount = 0;
    }
    
    protected override void RandomAction()
    {
        var randomIndex = Random.Range(1, 3);

        if(randomIndex == 1) Attack();
        else Reload();
        //RandomAttack(randomIndex);
    }
    
    private void Reload()
    {
        ResetCounters();
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        animator.Play(Variables.ReloadAnimName);
    }
}