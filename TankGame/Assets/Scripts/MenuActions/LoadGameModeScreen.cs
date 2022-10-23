using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MenuActions
{
    public class LoadGameModeScreen : MonoBehaviour
    {
		public Button button;
		public GameObject GameModeSelectionParentObject;
		public GameObject MainMenuParentObject;

		private bool isScreenVisible;

		void Start()
		{
			Button btn = button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);

			GameModeSelectionParentObject.SetActive(false);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) && isScreenVisible)
			{
				UpdateScreenVisible(false);
			}
		}

		private void TaskOnClick()
		{
			UpdateScreenVisible(true);
		}

		private void UpdateScreenVisible(bool isVisible)
		{
			MainMenuParentObject.SetActive(!isVisible);
			GameModeSelectionParentObject.SetActive(isVisible);

			isScreenVisible = isVisible;
		}
	}
}
