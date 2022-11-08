using Assets.Scripts.Constants.Names;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        public float cameraHeight = 15f;

        private PlayerLogic Player;

        private bool PlayerHitEsc => Input.GetKeyDown(KeyCode.Escape);

        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find(ObjectNames.Player).GetComponent<PlayerLogic>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                Vector3 targetPosition = Player.transform.transform.position;
                gameObject.transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - cameraHeight);
            }

            if (PlayerHitEsc)
            {
                SceneManager.LoadScene(SceneNames.MainMenu);
            }
        }
    }
}
