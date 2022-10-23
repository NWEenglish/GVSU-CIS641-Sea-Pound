using Assets.Scripts.Objective;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GeneralGameLogic
{
    public class GameModeEndScreen : MonoBehaviour
    {
        public GameObject Screen;
        public GameObject GameWonText;
        public GameObject GameLostText;

        void Start()
        {

        }

        void Update()
        {
            if (GameModeObjectives.ObjectivesComplete)
            {
                Screen.GetComponent<Image>().color = GetFadedColor(Color.green);
                GameWonText.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            else if (GameModeObjectives.ObjectivesFailed)
            {
                Screen.GetComponent<Image>().color = GetFadedColor(Color.red);
                GameLostText.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            else
            {
                Screen.GetComponent<Image>().color = Color.clear;
                GameWonText.GetComponent<TextMeshProUGUI>().color = Color.clear;
                GameLostText.GetComponent<TextMeshProUGUI>().color = Color.clear;
            }
        }

        private Color GetFadedColor(Color color)
        {
            var fadedColor = color;
            fadedColor.a = 0.5f;

            return fadedColor;
        }
    }
}
