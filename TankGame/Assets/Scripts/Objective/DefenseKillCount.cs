using Assets.Scripts.Constants.Types;

namespace Assets.Scripts.Objective
{
    public class DefenseKillCount
    {
        public int KillCount { get; private set; }

        public DefenseKillCount()
        {
            KillCount = 0;
        }

        public void AddKill(EntityType entityType)
        {
            if (entityType == EntityType.Guard || entityType == EntityType.Turret)
            {
                KillCount++;
            }
        }
    }
}
