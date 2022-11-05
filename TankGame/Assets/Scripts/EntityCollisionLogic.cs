using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using Assets.Scripts.Objective;
using UnityEngine;

public class EntityCollisionLogic : MonoBehaviour
{
    public EntityType EntityType;
    public GameObject CanPassThrough = null;

    private int EntityHealth;

    private readonly List<EntityType> TakesDamage = new List<EntityType>() { EntityType.Guard, EntityType.Turret, EntityType.Player, EntityType.ObjectiveHouse, EntityType.ObjectivePrototype, EntityType.ObjectiveEnemy };
    private readonly List<EntityType> PassThroughWalls = new List<EntityType>() { EntityType.Beam, EntityType.Missile };

    void Start()
    {
        BoxCollider2D currentCollider = gameObject.GetComponent<BoxCollider2D>();

        EntityHealth = HealthHelper.GetMaxHealth(EntityType);

        // Setup to let items pass through walls
        if (CanPassThrough != null && PassThroughWalls.Contains(EntityType))
        {
            IEnumerable<BoxCollider2D> boxColliders = CanPassThrough.GetComponentsInChildren<BoxCollider2D>();
            foreach (var boxCollider in boxColliders)
            {
                Physics2D.IgnoreCollision(boxCollider, currentCollider);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TakesDamage.Contains(EntityType))
        {
            DamageHelper.CalculateHealthOnCollision(ref EntityHealth, collision);
        }
    }

    void Update()
    {
        // Destory object if no health
        if (EntityHealth <= 0)
        {
            Objective objective = GameModeObjectives.GetObjectives().FirstOrDefault(obj => obj.Type == EntityType);

            if (objective != null)
            {
                objective.Completed = true;
                
                if (EntityType != EntityType.ObjectiveEnemy)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = ColorHelper.GetFadedColor(Color.black);
                    gameObject.transform.Find("MapIcon").GetComponent<SpriteRenderer>().color = Color.clear;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
