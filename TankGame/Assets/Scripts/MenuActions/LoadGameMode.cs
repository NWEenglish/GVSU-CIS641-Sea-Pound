using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.Objective;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
