using TMPro;
using UnityEngine;

namespace Assets.Scripts.Objective
{
    public class ObjectiveHUDLogic : MonoBehaviour
    {
        public GameObject Objective_HUD;

        void Start()
        {
            Objective_HUD.GetComponent<TextMeshProUGUI>().text = "";
        }

        void Update()
        {
            // Get game mode objective settings
            var objectives = GameModeObjectives.GetObjectives();
            
            // Update HUD for objectives 
            Objective_HUD.GetComponent<TextMeshProUGUI>().text = "";

            for (int index = 0; index < objectives.Count; index++)
            {
                if (objectives[index].Hidden == false)
                {
                    string text = $"\u2022<indent=1em>{objectives[index].Description}</indent>";
                    
                    if (objectives[index].Completed)
                    {
                        text = $"<color=green><alpha=#CC>{text}</color>";
                    }

                    Objective_HUD.GetComponent<TextMeshProUGUI>().text += $"{text}\n\n";
                }
                else
                {
                    Objective_HUD.GetComponent<TextMeshProUGUI>().text += "";
                }
            }
        }

    }
}
