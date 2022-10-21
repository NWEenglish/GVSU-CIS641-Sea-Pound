using System;
using System.Collections.Generic;
using Assets.Scripts.Names;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Objective
{
    public class ObjectiveLogic : MonoBehaviour
    {
        public List<GameObject> Objective_HUD_Items;
        public GameModeType GameMode;

        void Start()
        {
            foreach (var HUD_Item in Objective_HUD_Items)
{
                HUD_Item.GetComponent<TextMeshProUGUI>().text = "";
            }
        }

        void Update()
        {
            var objectives = GameModeObjectives.GetObjectives(GameMode);

            for(int index = 0; index < objectives.Count; index++)
            {
                // If not hidden, populate text
                if (objectives[index].Hidden == false)
                {
                    Objective_HUD_Items[index].GetComponent<TextMeshProUGUI>().text = "- " + objectives[index].Description;
                }
                else
                {
                    Objective_HUD_Items[index].GetComponent<TextMeshProUGUI>().text = "";
                }

                // If completed, strikethrough
                if (objectives[index].Completed)
                {
                    Objective_HUD_Items[index].GetComponent<TextMeshProUGUI>().text = $"<s>{Objective_HUD_Items[index].GetComponent<TextMeshProUGUI>().text}</s>";
                }
            }
        }

    }
}
