using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovementLogic : MonoBehaviour
    {
        public const float StartChaseRange = 15f;
        public const float StopChaseRange = 10f;
        public const float MaxSpeed = 2f;

        public const float AudioRange = 20f;

        public GameObject Player;
        public EntityType EnemyType;

        private Rigidbody2D Body;
        private AudioSource audioSource_Idle;
        private AudioSource audioSource_Moving;

        // Start is called before the first frame update
        void Start()
        {
            Body = gameObject.GetComponent<Rigidbody2D>();

            // Setup Audio Objects
            var audioSources = gameObject.GetComponents<AudioSource>();
            audioSource_Idle = audioSources[0];
            audioSource_Moving = audioSources[1];

            audioSource_Moving.loop = true;
            audioSource_Moving.Play();
            audioSource_Moving.volume = 0.2f;

            audioSource_Idle.loop = true;
            audioSource_Idle.Play();
            audioSource_Idle.volume = 0.1f;
        }

        void FixedUpdate()
        {
            if (Player == null)
            {
                return;
            }

            // Target Player
            Vector3 playerPosition = Player.transform.position;
            Vector3 currentPosition = Body.transform.position;
            Vector2 target = new Vector2(playerPosition.x - currentPosition.x, playerPosition.y - currentPosition.y);

            if (EnemyType == EntityType.Guard)
            {
                // Move towards player
                if (target.magnitude <= StartChaseRange && target.magnitude >= StopChaseRange)
                {
                    // Movement Logic
                    MovementHelper.Move(ref Body, target.x, target.y, MaxSpeed);
                    MovementHelper.Rotate(ref Body, target, -90f);

                    // Audio Logic
                    audioSource_Idle.mute = true;
                    audioSource_Moving.mute = false;
                }
                else
                {
                    // Movement Logic
                    MovementHelper.Move(ref Body, 0, 0, 3f);

                    // Audio Logic
                    audioSource_Idle.mute = false;
                    audioSource_Moving.mute = true;
                }
            }

            if (target.magnitude > AudioRange)
            {
                audioSource_Idle.mute = true;
                audioSource_Moving.mute = true;
            }
        }

        // Update is called once per frame
        void Update() { }
    }
}
