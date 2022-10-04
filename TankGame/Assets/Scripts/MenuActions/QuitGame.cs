using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MenuActions
{
    public class QuitGame : MonoBehaviour
    {
		public Button button;

		void Start()
		{
			Button btn = button.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif

			Application.Quit();
		}
	}
}
