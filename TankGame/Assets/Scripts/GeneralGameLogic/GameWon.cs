using Assets.Scripts.Objective;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GeneralGameLogic
{
    public class GameWon : MonoBehaviour
    {
        public GameObject Screen;
        public GameObject Text;

        void Start()
        {
            Screen.GetComponent<Image>().color = Color.clear;
            Text.GetComponent<TextMeshProUGUI>().color = Color.clear;
        }

        void Update()
        {
            if (GameModeObjectives.ObjectivesComplete)
            {
                Screen.GetComponent<Image>().color = GreenFade();
                Text.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
        }

        private Color GreenFade()
        {
            var temp = Color.green;
            temp.a = 0.5f;

            return temp;
        }
    }
}
