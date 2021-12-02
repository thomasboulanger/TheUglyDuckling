using UnityEngine;

public class Boss3AI : BossManager
{
    private bool _phase2;
        
    protected override void Update()
    {
        base.Update();

        IsPhase2();
    }
        
    protected override void EnemyActions()
    {
        if (IsActive) return;
        
        BoxCollider2D.enabled = true;
            
        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (ActionCount == 0)
        {
            if (!_phase2)
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
            }
            else
            {
                RandomIndex = Random.Range(Variables.FirstActionIndex, 5);

                switch (RandomIndex)
                {
                    case 0:
                    case 1:
                    case 2:
                        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case 3:
                        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.blue;
                        break;
                    case 4:
                        cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
                        break;
                }
            }
            
            
            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        ActionCount++;
        
        if (ActionCount != 4) return;
        
        RandomAction();

        ActionCount = 0;
    }

    #region RandomActions
    protected override void RandomAction()
    {
        if(!_phase2) RandomActionPhase1(RandomIndex);
        else RandomActionPhase2(RandomIndex);
    }
        
    private void RandomActionPhase1(int index)
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

    private void RandomActionPhase2(int index)
    {
        switch (index)
        {
            case 0:
            case 1:
            case 2:
                Attack(index, 1);
                break;
            case 3:
                Dodge();
                break;
            case 4:
                Rest();
                break;
        }
    }
    #endregion
        
    private void IsPhase2() => _phase2 = Health <= Variables.BossHealthToPhase2;
}