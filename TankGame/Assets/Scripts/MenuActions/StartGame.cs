using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Names;

namespace Assets.Scripts.MenuActions
{
    public class StartGame : MonoBehaviour
    {
		public Button button;

		void Start()
		{
			Button btn = button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		private void TaskOnClick()
		{
			SceneManager.LoadScene(SceneNames.Sandbox);
		}
	}
}
