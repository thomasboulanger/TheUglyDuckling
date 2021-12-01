using UnityEngine;

public class Boss1AI : BossManager
{
    protected override void EnemyActions()
    {
        if (IsActive) return;

        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (ActionCount == 0)
        {
            cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;

            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        ActionCount++;

        if (ActionCount != 4) return;
        
        if(AttackCount == maxActionRepetition) Reload();
        else Attack(0, 5);
        
        ActionCount = 0;
    }
    
    private void Reload()
    {
        ResetCounters();
        
        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.yellow;
        
        Animator.Play(Variables.ReloadAnimName);
    }
}