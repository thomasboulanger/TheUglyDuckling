public class Boss1AI : BossManager
{
    protected override void EnemyActions()
    {
        if (isActive) return;
            
        if(attackCount == maxActionRepetition) Reload();
        else RandomAction();
    }
}