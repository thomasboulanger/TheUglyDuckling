using UnityEngine;

public class Boss3AI : BossManager
{
    [SerializeField] private int nbAttacksPhase1;
        
    private bool _phase2;
        
    protected override void Update()
    {
        base.Update();

        IsPhase2();
    }
        
    protected override void EnemyActions()
    {
        if (!isActive) RandomAction();
    }

    #region RandomActions
    protected override void RandomAction()
    {
        if(!_phase2) RandomActionPhase1();
        else RandomActionPhase2();
    }
        
    private void RandomActionPhase1()
    {
        var randomIndex = Random.Range(1, Variables.NbActions + nbAttacksPhase1);
            
        RandomAttack(randomIndex);
            
        Rest();
    }

    private void RandomActionPhase2()
    {
        var randomIndex = Random.Range(1, Variables.NbActions + nbAttacks + 1);
            
        RandomAttack(randomIndex);
            
        if(randomIndex == nbAttacks + 1) Rest();
        else Dodge();
    }
    #endregion
        
    private void IsPhase2() => _phase2 = Health <= Variables.BossHealthToPhase2;
}