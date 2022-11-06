using Assets.Scripts.Helpers;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using UnityEngine;
using Assets.Scripts.GeneralGameLogic;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovementLogic : MonoBehaviour
    {
        
        private float StartChaseRange = 15f;
        private const float StopChaseRange = 10f;
        private const float MaxSpeed = 2f;
        private const float AudioRange = 20f;

        private EntityType Type;
        private Vector2 Movement;        
        private Rigidbody2D Body;
        private GameObject Player;
        private AudioHelper AudioHelper;

        void Start()
        {
            if (GameObject.Find(ObjectNames.GameLogic).GetComponent<GameModeSetup>().GameMode == GameModeType.Defensive)
            {
                StartChaseRange = 1000f;
            }

            Body = gameObject.GetComponent<Rigidbody2D>();
            Player = GameObject.Find(ObjectNames.Player);
            Type = gameObject.GetComponent<EntityCollisionLogic>().EntityType;

            AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
            AudioHelper = new AudioHelper(audioSources[0], audioSources[1], 0.2f);
        }

        void FixedUpdate()
        {
            Vector2? target = GetTarget(Player);

            if (target != null)
            {
                UpdateMovement(target.Value);
                UpdateAudio(target.Value);
            }
        }

        private Vector2? GetTarget(GameObject target)
        {
            if (target == null)
            {
                return null;
            }

            Vector3 targetPosition = target.transform.position;
            Vector3 currentPosition = Body.transform.position;

            return new Vector2(targetPosition.x - currentPosition.x, targetPosition.y - currentPosition.y);
        }

        private void UpdateMovement(Vector2 target)
        {
            if (Type == EntityType.Guard)
            {
                // Movement Logic - Move towards target or stop movement
                if (target.magnitude <= StartChaseRange && target.magnitude >= StopChaseRange)
                {
                    Movement = MovementHelper.Move(ref Body, target.x, target.y, MaxSpeed);
                    MovementHelper.Rotate(ref Body, target, -90f);
                }
                else
                {
                    Movement = MovementHelper.Move(ref Body, 0, 0, 3f);
                }
            }

            if (MovementHelper.IsOutOfBounds(gameObject))
            {
                Destroy(gameObject);
            }
        }

        private void UpdateAudio(Vector2 target)
        {
            if (target.magnitude > AudioRange)
            {
                AudioHelper.MuteAudio();
            }
            else
            {
                AudioHelper.PlayAudio(Movement);
            }
        }
    }
}
