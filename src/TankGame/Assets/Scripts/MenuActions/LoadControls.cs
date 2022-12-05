using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MenuActions
{
    public class LoadControls : MonoBehaviour
    {
        public Button button;
        public GameObject ControlsParentObject;
        public GameObject MainMenuParentObject;

        private bool isControlsScreenVisible;

        void Start()
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);

            TextAsset controlsText = Resources.Load<TextAsset>("Text/Controls");
            PopulateSources(controlsText.text, GameObject.Find("ControlsText"));

            ControlsParentObject.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isControlsScreenVisible)
            {
                UpdateCreditScreenVisible(false);
            }
        }

        private void TaskOnClick()
        {
            UpdateCreditScreenVisible(true);
        }

        private void UpdateCreditScreenVisible(bool isVisible)
        {
            MainMenuParentObject.SetActive(!isVisible);
            ControlsParentObject.SetActive(isVisible);

            isControlsScreenVisible = isVisible;
        }

        private void PopulateSources(string source, GameObject gameObjectToPopulate)
        {
            gameObjectToPopulate.GetComponent<TextMeshProUGUI>().text = "";
            foreach (string line in SourceTextSplitter.Split(source))
            {
                gameObjectToPopulate.GetComponent<TextMeshProUGUI>().text += $"{line}\n";
            }
        }
    }
}
