using System.Collections.Generic;
using Assets.Scripts.Names;
using UnityEngine;

public class EntityLogic : MonoBehaviour
{
    public EntityType _EntityType;
    public GameObject Boundary = null;

    public int VisableHealth;
    private int ActualHealth;

    private int MissileDamage = 25;
    private int BeamDamage = 15;

    private List<EntityType> TakesDamage = new List<EntityType>() { EntityType.Guard, EntityType.Turret, EntityType.Player };
    private List<EntityType> PassThroughWalls = new List<EntityType>() { EntityType.Beam, EntityType.Missile };

    // Start is called before the first frame update
    void Start()
    {
        switch (_EntityType)
        {
            case EntityType.Player:
                ActualHealth = 200;
                break;
            case EntityType.Guard:
                ActualHealth = 75;
                break;
            case EntityType.Turret:
                ActualHealth = 50;
                break;
            default:
                ActualHealth = 1;
                break;
        }
        VisableHealth = ActualHealth;

        // Setup to let items pass through walls
        if (Boundary != null && PassThroughWalls.Contains(_EntityType))
        {
            IEnumerable<BoxCollider2D> boxColliders = Boundary.GetComponentsInChildren<BoxCollider2D>();
            BoxCollider2D currentCollider = gameObject.GetComponent<BoxCollider2D>();

            foreach (var boxCollider in boxColliders)
            {
                Physics2D.IgnoreCollision(boxCollider, currentCollider);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TakesDamage.Contains(_EntityType))
        {
            if (collision.collider.name.Contains(CollidableObjectNames.Missile))
            {
                collision.gameObject.transform.position = new Vector3(-100, -100, 0);
                ActualHealth -= MissileDamage;
            }
            else if (collision.collider.name.Contains(CollidableObjectNames.Beam))
            {
                collision.gameObject.transform.position = new Vector3(-100, -100, 0);
                ActualHealth -= BeamDamage;
            }
        }

        VisableHealth = ActualHealth;

        // Destory object if no health
        if (ActualHealth <= 0)
        {
            Object.Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
