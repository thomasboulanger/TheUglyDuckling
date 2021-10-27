namespace Scenes.Jordan.Scripts
{
    public class Boss1AI : BossManager
    {
        protected override void EnemyActions()
        {
            if (IsActive) return;
            
            if(AttackCount == maxActionRepetition) Reload();
            else RandomAction();
        }
    }
}