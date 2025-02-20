﻿using Assets.Scripts.Constants.Types;

namespace Assets.Scripts.Helpers
{
    public static class HealthHelper
    {
        public static int GetMaxHealth(EntityType entityType)
        {
            int Health;

            switch (entityType)
            {
                case EntityType.Player:
                    Health = 200;
                    break;
                case EntityType.Guard:
                    Health = 75;
                    break;
                case EntityType.ObjectiveEnemy:
                    Health = 100;
                    break;
                case EntityType.Turret:
                    Health = 50;
                    break;
                case EntityType.ObjectiveHouse:
                    Health = 100;
                    break;
                case EntityType.ObjectivePrototype:
                    Health = 125;
                    break;
                default:
                    Health = 1;
                    break;
            }

            return Health;
        }
    }
}
