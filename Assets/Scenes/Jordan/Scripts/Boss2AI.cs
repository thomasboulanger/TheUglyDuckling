namespace Scenes.Jordan.Scripts
{
    public class Boss2AI : BossManager
    {
        protected override void EnemyActions()
        {
            if (IsActive) return;
            
            if(AttackCount == maxActionRepetition) Rest();
            else RandomAction();
        }
        
        protected override void RandomAction()
        {
            base.RandomAction();
            
            Dodge();
        }
    }
}