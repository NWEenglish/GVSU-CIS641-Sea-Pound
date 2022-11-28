using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using UnityEngine;

namespace Assets.Scripts.Objective
{
    public class Objective
    {
        public string Description;
        public bool Completed = false;
        public EntityType Type;
    }

    public class GameModeObjectives
    {
        public bool ObjectivesComplete => Objectives.ToList().TrueForAll(obj => obj.Completed) && Objectives.ToList().Count > 0;
        public bool ObjectivesFailed => AreObjectivesFailed();

        public IEnumerable<Objective> Objectives { get; private set; }

        public GameModeObjectives(GameModeType gameMode)
        {
            Objectives = GetObjectives(gameMode);
        }

        public void MarkObjectiveComplete(Objective objective)
        {
            Objective currentObjectivite = Objectives.FirstOrDefault(obj => obj.Description == objective.Description && obj.Completed == false);
            
            if (currentObjectivite != null)
            {
                currentObjectivite.Completed = true;
            }
        }

        private IEnumerable<Objective> GetObjectives(GameModeType gameMode)
        {
            List<Objective> objectives;

            switch (gameMode)
            {
                case GameModeType.Defensive:
                    objectives = DefensiveObjectives;
                    break;
                case GameModeType.Offensive:
                    objectives = OffensiveObjectives;
                    break;
                default:
                    objectives = SandboxObjectives;
                    break;
            }

            return objectives;
        }

        private List<Objective> DefensiveObjectives = new List<Objective>()
        {
            new Objective()
            {
                Description = "Survive",
                Completed = false,
                Type = EntityType.Player
            }
        };

        private List<Objective> OffensiveObjectives = new List<Objective>()
        {
            new Objective()
            {
                Description = "Eliminate the target",
                Completed = false,
                Type = EntityType.ObjectiveEnemy
            },
            new Objective()
            {
                Description = "Destroy the building",
                Completed = false,
                Type = EntityType.ObjectiveHouse
            },
            new Objective()
            {
                Description = "Destroy the prototype turret",
                Completed = false,
                Type = EntityType.ObjectivePrototype
            }
        };

        private List<Objective> SandboxObjectives = new List<Objective>()
        {
            new Objective() 
            {
                Description = "Just have fun!"
            }
        };

        private bool AreObjectivesFailed()
        {
            bool playerAlive;

            if (GameObject.Find(ObjectNames.Player) == null)
            {
                playerAlive = false;
            }
            else
            {
                playerAlive = true;
            }

            return !playerAlive;
        }
    }
}
