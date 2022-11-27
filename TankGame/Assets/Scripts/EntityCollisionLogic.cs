using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.GeneralGameLogic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Objective;
using UnityEngine;

public class EntityCollisionLogic : MonoBehaviour
{
    public EntityType EntityType;
    public GameObject CanPassThrough = null;

    private bool wasDeathAnimationRan = false;
    private int EntityHealth;
    private GameModeObjectives GameModeObjectives;
    private DefenseKillCount DefenseKillCount;

    private readonly List<EntityType> TakesDamage = new List<EntityType>() { EntityType.Guard, EntityType.Turret, EntityType.Player, EntityType.ObjectiveHouse, EntityType.ObjectivePrototype, EntityType.ObjectiveEnemy };
    private readonly List<EntityType> BulletTypes = new List<EntityType>() { EntityType.Beam, EntityType.Missile };

    void Start()
    {
        BoxCollider2D currentCollider = gameObject.GetComponent<BoxCollider2D>();
        GameModeObjectives = GameObject.Find(ObjectNames.GameLogic).GetComponent<GameModeSetup>().GameModeObjectives;
        DefenseKillCount = GameObject.Find(ObjectNames.GameLogic).GetComponent<GameModeSetup>().DefenseKillCount;
        EntityHealth = HealthHelper.GetMaxHealth(EntityType);

        // Setup to let items pass through walls
        if (CanPassThrough != null && BulletTypes.Contains(EntityType))
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
        if (BulletTypes.Contains(EntityType) && collision != null)
        {
            HandleBulletsCollision(gameObject.transform.position);
        }
        else if (TakesDamage.Contains(EntityType))
        {
            DamageHelper.CalculateHealthOnCollision(ref EntityHealth, collision);
        }
    }

    private void HandleBulletsCollision(Vector3 position)
    {
        try
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Instantiate(GameObject.Find(ObjectNames.Explosion), position, new Quaternion()).GetComponent<ExplosionLogic>().Init(false);
        }
        catch (System.Exception e)
        {
            // We sometimes get conflicting messages about the game object being null.
            // This appears to be due to a race condition, but it seems we still get the correct output.
        }
    }

    void Update()
    {
        // Destory object if no health
        if (EntityHealth <= 0)
        {
            Objective objective = GameModeObjectives.Objectives.FirstOrDefault(obj => obj.Type == EntityType);

            if (objective != null)
            {
                GameModeObjectives.MarkObjectiveComplete(objective);
                
                if (EntityType != EntityType.ObjectiveEnemy)
                {
                    if (!wasDeathAnimationRan)
                    {
                        Instantiate(GameObject.Find(ObjectNames.Explosion), gameObject.transform.position, new Quaternion()).GetComponent<ExplosionLogic>().Init(true);
                        gameObject.GetComponent<SpriteRenderer>().color = ColorHelper.GetFadedColor(Color.black);
                        gameObject.transform.Find("MapIcon").GetComponent<SpriteRenderer>().color = Color.clear;
                        wasDeathAnimationRan = true;
                    }
                }
                else
                {
                    OnDeath();
                }
            }
            else
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        if (DefenseKillCount != null)
        {
            DefenseKillCount.AddKill(EntityType);
        }

        Instantiate(GameObject.Find(ObjectNames.Explosion), gameObject.transform.position, new Quaternion()).GetComponent<ExplosionLogic>().Init(true);
        Destroy(gameObject);
    }
}
