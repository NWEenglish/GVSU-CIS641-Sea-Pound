using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.GeneralGameLogic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Objective
{
    public class ObjectiveHUDLogic : MonoBehaviour
    {
        public GameObject Objective_HUD;

        private GameModeObjectives GameModeObjectives;

        void Start()
        {            
            Objective_HUD.GetComponent<TextMeshProUGUI>().text = "";
            GameModeObjectives = GameObject.Find(ObjectNames.GameLogic).GetComponent<GameModeSetup>().GameModeObjectives;
        }

        void Update()
        {
            List<Objective> objectives = GameModeObjectives.Objectives.ToList();

            // Update HUD for objectives 
            Objective_HUD.GetComponent<TextMeshProUGUI>().text = "";

            for (int index = 0; index < objectives.Count; index++)
            {
                string text = $"\u2022<indent=1em>{objectives[index].Description}</indent>";
                    
                if (objectives[index].Completed)
                {
                    text = $"<color=green><alpha=#CC>{text}</color>";
                }

                Objective_HUD.GetComponent<TextMeshProUGUI>().text += $"{text}\n\n";
            }
        }

    }
}
