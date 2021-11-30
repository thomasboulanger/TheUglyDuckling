using UnityEngine;

public class Boss3AI : BossManager
{
    [SerializeField] private int nbAttacksPhase1;
        
    public bool _phase2;
        
    protected override void Update()
    {
        base.Update();

        IsPhase2();
    }
        
    protected override void EnemyActions()
    {
        if (IsActive) return;
            
        if (!(BeatManager.beatTimer >= BeatManager.beatInterval)) return;
        
        if (actionCount == 0)
        {
            if (!_phase2)
            {
                randomIndex = Random.Range(Variables.FirstActionIndex, 4);
            
                if(randomIndex == 0 || randomIndex == 1) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
                else if(randomIndex == 2) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.blue;
                else if(randomIndex == 3) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            else
            {
                randomIndex = Random.Range(Variables.FirstActionIndex, 5);
            
                if(randomIndex == 0 || randomIndex == 1 || randomIndex == 2) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.red;
                else if(randomIndex == 3) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.blue;
                else if(randomIndex == 4) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            
            
            if(AttackCount == maxActionRepetition) cubeDisplay.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        
        actionCount++;
        
        if (actionCount != 4) return;
        
        RandomAction();

        actionCount = 0;
    }

    #region RandomActions
    protected override void RandomAction()
    {
        if(!_phase2) RandomActionPhase1(randomIndex);
        else RandomActionPhase2(randomIndex);
    }
        
    private void RandomActionPhase1(int index)
    {
        if(index == 0 || index == 1) Attack(index);
        else if(index == 2) Dodge();
        else if(index == 3) Rest();
    }

    private void RandomActionPhase2(int index)
    {
        if(index == 0 || index == 1 || index == 2) Attack(index);
        else if(index == 3) Dodge();
        else if(index == 4) Rest();
    }
    #endregion
        
    private void IsPhase2() => _phase2 = Health <= Variables.BossHealthToPhase2;
}