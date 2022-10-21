using System.Collections.Generic;
using Assets.Scripts.Names;
using TMPro;
using UnityEngine;

public class EntityLogic : MonoBehaviour
{
    public EntityType _EntityType;
    public GameObject Boundary = null;
    public GameObject Health_HUD;

    public int Health { get; private set; }

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
                Health = 200;
                break;
            case EntityType.Guard:
                Health = 75;
                break;
            case EntityType.Turret:
                Health = 50;
                break;
            default:
                Health = 1;
                break;
        }
        Health = Health;

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
                Health -= MissileDamage;
            }
            else if (collision.collider.name.Contains(CollidableObjectNames.Beam))
            {
                collision.gameObject.transform.position = new Vector3(-100, -100, 0);
                Health -= BeamDamage;
            }
        }

        Health = Health;

        // Destory object if no health
        if (Health <= 0)
        {
            Object.Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Health_HUD != null)
        {
            Health_HUD.GetComponent<TextMeshProUGUI>().text = $"Health: {Health}";
            if (Health < 50)
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
        }
    }
}
