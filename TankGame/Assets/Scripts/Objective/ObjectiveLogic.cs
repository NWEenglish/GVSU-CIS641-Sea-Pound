using Assets.Scripts.Names;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Objective
{
    public class ObjectiveLogic : MonoBehaviour
    {
        public GameObject Objective_HUD;
        public GameModeType GameMode;

        void Start()
        {
            Objective_HUD.GetComponent<TextMeshProUGUI>().text = "";
        }

        void Update()
        {
            var objectives = GameModeObjectives.GetObjectives(GameMode);
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
