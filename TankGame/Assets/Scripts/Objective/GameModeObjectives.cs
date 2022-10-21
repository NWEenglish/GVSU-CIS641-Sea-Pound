using System.Collections.Generic;
using Assets.Scripts.Names;

namespace Assets.Scripts.Objective
{
    public class Objective
    {
        public string Description;
        public bool Hidden = false;
        public bool Completed = false;
    }

    public static class GameModeObjectives
    {
        public static List<Objective> GetObjectives(GameModeType? gameModeType)
        {
            switch (gameModeType)
            {
                case GameModeType.Defensive:
                    return DefensiveObjectives;
                case GameModeType.Offensive:
                    return OffensiveObjectives;
                default:
                    return SandboxObjectives;
            }
        }

        private static List<Objective> DefensiveObjectives = new List<Objective>()
        {
            new Objective()
            {
                Description = "Survive for as long as you can!"
            }
        };

        private static List<Objective> OffensiveObjectives = new List<Objective>()
        {
            new Objective()
            {
                Description = "Destroy the objectives!"
            },
            new Objective()
            {
                Description = "Destroy the objectives!"
            },
            new Objective()
            {
                Description = "Destroy the objectives!"
            }
        };

        private static List<Objective> SandboxObjectives = new List<Objective>()
        {
            new Objective() 
            {
                Description = "Just have fun!"
            }
        };
    }
}
