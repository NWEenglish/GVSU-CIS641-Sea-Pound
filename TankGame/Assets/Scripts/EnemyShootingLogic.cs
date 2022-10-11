using System;
using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using UnityEngine;

public class EnemyShootingLogic : MonoBehaviour
{
    public float AimRange = 15f;
    public float ShootRange = 12f;

    public GameObject Player;
    public GameObject Muzzle;
    public GameObject AltMuzzle;
    public GameObject Bullet;
    public EntityType _EnemyType;

    private Rigidbody2D BarrelPivot;
    private DateTime LastFire = DateTime.Now;
    private GameObject LastShotFrom = null;

    // Start is called before the first frame update
    void Start()
    {
        BarrelPivot = gameObject.GetComponent<Rigidbody2D>();
        LastShotFrom = Muzzle;
    }

    void FixedUpdate()
    {
        // Target Player
        Vector3 playerPosition = Player.transform.position;
        Vector3 currentPosition = BarrelPivot.transform.position;
        Vector2 target = new Vector2(playerPosition.x - currentPosition.x, playerPosition.y - currentPosition.y);

        // Rotate towards player
        if (target.magnitude <= AimRange)
        {
            MovementHelper.Rotate(ref BarrelPivot, target, 90f);
        }

        // Shoot at player
        if (target.magnitude <= ShootRange)
        {
            if (DateTime.Now > LastFire.AddSeconds(ShootingHelper.GetCooldown(_EnemyType)))
            {
                if (LastShotFrom == AltMuzzle || AltMuzzle == null)
                {
                    ShootingHelper.Shoot(Bullet, Muzzle.transform.position, BarrelPivot.rotation, _EnemyType != EntityType.Turret);
                    LastShotFrom = Muzzle;
                }
                else
                {
                    ShootingHelper.Shoot(Bullet, AltMuzzle.transform.position, BarrelPivot.rotation, _EnemyType != EntityType.Turret);
                    LastShotFrom = AltMuzzle;
                }

                LastFire = DateTime.Now;
            }
        }
    }

    // Update is called once per frame
    void Update() { }
}
