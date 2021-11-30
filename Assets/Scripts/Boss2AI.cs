using UnityEngine;

public class Boss2AI : BossManager
{
    protected override void EnemyActions()
    {
        if (IsActive) return;
            
        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (actionCount == 0)
        {
            randomIndex = Random.Range(Variables.FirstActionIndex, 4);
            
            if(randomIndex == 0 || randomIndex == 1) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
            else if(randomIndex == 2) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.blue;
            else if(randomIndex == 3) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
            
            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;

        if (actionCount != 4) return;
        
        if(AttackCount == maxActionRepetition) Rest();
        else RandomAction(randomIndex);
        
        actionCount = 0;
    }
        
    protected override void RandomAction(int index)
    {
        if(index == 0 || index == 1) Attack(index);
        else if(index == 2) Dodge();
        else if(index == 3) Rest();
    }
    
}