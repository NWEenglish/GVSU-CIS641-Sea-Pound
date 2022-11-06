using Assets.Scripts.Names;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        public float cameraHeight = 15f;

        private PlayerLogic Player;
        private PlayerCamera MainCamera;

        private bool PlayerHitEsc => Input.GetKeyDown(KeyCode.Escape);

        // Start is called before the first frame update
        void Start()
        {
            Player = GameObject.Find(EntityNames.Player).GetComponent<PlayerLogic>();
            MainCamera = gameObject.GetComponent<PlayerCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                Vector3 targetPosition = Player.transform.transform.position;
                MainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - cameraHeight);
            }

            if (PlayerHitEsc)
            {
                SceneManager.LoadScene(SceneNames.MainMenu);
            }
        }
    }
}
