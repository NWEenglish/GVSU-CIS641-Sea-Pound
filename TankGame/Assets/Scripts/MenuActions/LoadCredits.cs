using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Names;
using TMPro;
using System.IO;

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

			PopulateSources(Path.GetFullPath("Assets/Resources/Audio Sources.txt"), GameObject.Find("AudioCredits"));
			PopulateSources(Path.GetFullPath("Assets/Resources/Sprite Sources.txt"), GameObject.Find("SpriteCredits"));

			CreditsParentObject.SetActive(false);
		}

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && isCreditScreenVisible)
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
			foreach (string line in File.ReadAllLines(source))
			{
				gameObjectToPopulate.GetComponent<TextMeshProUGUI>().text += $"- {line.Split(" - ")[2]}\n";
			}
		}
	}
}
