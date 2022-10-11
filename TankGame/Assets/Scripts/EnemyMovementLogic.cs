using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using UnityEngine;

public class EnemyMovementLogic : MonoBehaviour
{
    public const float StartChaseRange = 15f;
    public const float StopChaseRange = 10f;
    public const float MaxSpeed = 2f;

    public GameObject Player;
    public EnemyType EnemyType;

    private Rigidbody2D Body;

    // Start is called before the first frame update
    void Start()
    {
        Body = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Target Player
        Vector3 playerPosition = Player.transform.position;
        Vector3 currentPosition = Body.transform.position;
        Vector2 target = new Vector2(playerPosition.x - currentPosition.x, playerPosition.y - currentPosition.y);

        if (EnemyType == EnemyType.Gaurd)
        {
            // Move towards player
            if (target.magnitude <= StartChaseRange && target.magnitude >= StopChaseRange)
            {
                MovementHelper.Move(ref Body, target.x, target.y, MaxSpeed);
                MovementHelper.Rotate(ref Body, target, -90f);
            }
            else
            {
                MovementHelper.Move(ref Body, 0, 0, 3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
