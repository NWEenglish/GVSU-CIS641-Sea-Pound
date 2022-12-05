using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MenuActions
{
    public class LoadCredits : MonoBehaviour
	{
		public Button button;
		public GameObject CreditsParentObject;
		public GameObject MainMenuParentObject;

		private bool isCreditScreenVisible;

		void Start()
		{
			Button btn = button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);

			TextAsset audioSourcesText = Resources.Load<TextAsset>("Text/Audio Sources");
			PopulateSources(audioSourcesText.text, GameObject.Find("AudioCredits"));

			TextAsset spriteSourcesText = Resources.Load<TextAsset>("Text/Sprite Sources");
			PopulateSources(spriteSourcesText.text, GameObject.Find("SpriteCredits"));

			CreditsParentObject.SetActive(false);
		}

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isCreditScreenVisible)
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
			CreditsParentObject.SetActive(isVisible);

			isCreditScreenVisible = isVisible;
		}

		private void PopulateSources(string source, GameObject gameObjectToPopulate)
		{
			gameObjectToPopulate.GetComponent<TextMeshProUGUI>().text = "";
			foreach (string line in SourceTextSplitter.Split(source))
			{
				gameObjectToPopulate.GetComponent<TextMeshProUGUI>().text += $"- {line.Split(" - ")[2]}\n";
			}
		}
	}
}
