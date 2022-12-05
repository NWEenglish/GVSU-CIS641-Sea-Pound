using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class DamageHelper
    {
        private const int MissileDamage = 25;
        private const int BeamDamage = 15;

        public static void CalculateHealthOnCollision(ref int health, Collision2D collision)
        {
            health = CalculateHealthOnCollision(health, collision);
        }

        public static int CalculateHealthOnCollision(int health, Collision2D collision)
        {
            if (collision.collider.name.Contains(CollidableObjectNames.Missile))
            {
                health -= GetDamage(EntityType.Missile);
            }
            else if (collision.collider.name.Contains(CollidableObjectNames.Beam))
            {
                health -= GetDamage(EntityType.Beam);
            }

            return health;
        }

        private static int GetDamage(EntityType entityType)
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
