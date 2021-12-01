using UnityEngine;

public class Boss2AI : BossManager
{
    protected override void EnemyActions()
    {
        if (IsActive) return;
            
        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (ActionCount == 0)
        {
            RandomIndex = Random.Range(Variables.FirstActionIndex, 4);
            
            switch (RandomIndex)
            {
                case 0:
                case 1:
                    cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 2:
                    cubeDisplay.GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case 3:
                    cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
            }
            
            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        ActionCount++;

        if (ActionCount != 4) return;
        
        if(AttackCount == maxActionRepetition) Rest();
        else RandomAction(RandomIndex);
        
        ActionCount = 0;
    }
        
    protected override void RandomAction(int index)
    {
        switch (index)
        {
            case 0:
            case 1:
                Attack(index, 1);
                break;
            case 2:
                Dodge();
                break;
            case 3:
                Rest();
                break;
        }
    }
    
}