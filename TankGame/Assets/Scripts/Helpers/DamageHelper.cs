using Assets.Scripts.Names;

namespace Assets.Scripts.Helpers
{
    public static class DamageHelper
    {
        private const int MissileDamage = 25;
        private const int BeamDamage = 15;

        public static int GetDamage(EntityType entityType)
        {
            switch (entityType)
            {
                case EntityType.Missile:
                    return MissileDamage;
                case EntityType.Beam:
                    return BeamDamage;
                default:
                    return 0;
            }           
        }
    }
}
