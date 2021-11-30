using UnityEngine;

public class Boss1AI : BossManager
{
    protected override void EnemyActions()
    {
        if (IsActive) return;

        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (actionCount == 0)
        {
            cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;

            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;

        if (actionCount != 4) return;
        
        if(AttackCount == maxActionRepetition) Reload();
        else Attack();
        
        actionCount = 0;
    }
    
    protected override void RandomAction()
    {
        var randomIndex = Random.Range(1, 3);

        if(randomIndex == 1) Attack();
        else Reload();
    }
    
    private void Reload()
    {
        ResetCounters();
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.ReloadAnimName);
    }
}