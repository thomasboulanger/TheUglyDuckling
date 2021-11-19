public class Boss2AI : BossManager
{
    protected override void EnemyActions()
    {
        if (isActive) return;
            
        if(attackCount == maxActionRepetition) Rest();
        else RandomAction();
    }
        
    protected override void RandomAction()
    {
        base.RandomAction();
            
        Dodge();
    }
}