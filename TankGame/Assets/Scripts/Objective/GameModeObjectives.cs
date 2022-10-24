using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Names;

namespace Assets.Scripts.Objective
{
    public class Objective
    {
        public string Description;
        public bool Hidden = false;
        public bool Completed = false;
        public EntityType Type;
    }

    public static class GameModeObjectives
    {
        public static bool ObjectivesComplete => CurrentObjectives.TrueForAll(obj => obj.Completed) && CurrentObjectives.Count > 0;
        public static bool ObjectivesFailed => PlayerStatusHelper.IsPlayerAlive == false;

        private static List<Objective> CurrentObjectives = new List<Objective>();

        public static List<Objective> GetObjectives(GameModeType gameModeType)
        {
            if (CurrentObjectives.Count == 0)
            {
                switch (gameModeType)
                {
                    case GameModeType.Defensive:
                        CurrentObjectives = DefensiveObjectives;
                        break;
                    case GameModeType.Offensive:
                        CurrentObjectives = OffensiveObjectives;
                        break;
                    default:
                        CurrentObjectives = SandboxObjectives;
                        break;
                }
            }

            return CurrentObjectives;
        }

        public static void ClearObjectives()
        {
            CurrentObjectives = new List<Objective>();
        }

        private static List<Objective> DefensiveObjectives => new List<Objective>()
        {
            new Objective()
            {
                Description = "Survive for as long as you can!"
            }
        };

        private static List<Objective> OffensiveObjectives => new List<Objective>()
        {
            new Objective()
            {
                Description = "Eliminate the target",
                Hidden = false,
                Completed = false,
                Type = EntityType.ObjectiveEnemy
            },
            new Objective()
            {
                Description = "Destroy the building",
                Hidden = false,
                Completed = false,
                Type = EntityType.ObjectiveHouse
            },
            new Objective()
            {
                Description = "Destroy the prototype turret",
                Hidden = false,
                Completed = false,
                Type = EntityType.ObjectivePrototype
            }
        };

        private static List<Objective> SandboxObjectives => new List<Objective>()
        {
            new Objective() 
            {
                Description = "Just have fun!"
            }
        };
    }
}
