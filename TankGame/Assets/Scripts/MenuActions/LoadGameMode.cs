using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Names;

namespace Assets.Scripts.MenuActions
{
    public class LoadGameMode : MonoBehaviour
    {
		public GameModeType GameMode;

		void Start()
		{
			Button btn = gameObject.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		private void TaskOnClick()
		{
			SceneManager.LoadScene(GetSceneName());
		}

		private string GetSceneName()
        {
			switch (GameMode)
            {
				case GameModeType.Offensive:
					return SceneNames.Offense;
				case GameModeType.Defensive:
					return SceneNames.Defense;
				default:
					return SceneNames.MainMenu;
            }
        }
	}
}
