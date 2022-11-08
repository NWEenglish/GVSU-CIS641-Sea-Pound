using System;
using Assets.Scripts.Helpers;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyShootingLogic : MonoBehaviour
    {
        public float AimRange = 30f;
        public float ShootRange = 12f;

        private EntityType Type;
        private DateTime LastFire = DateTime.Now;
        private Rigidbody2D Barrel;
        private GameObject LastShotFrom;
        private GameObject Player;
        private GameObject Bullet;
        private GameObject Muzzle;
        private GameObject AltMuzzle;

        // Start is called before the first frame update
        void Start()
        {
            Type = gameObject.GetComponentInParent<EntityCollisionLogic>().EntityType;
            Player = GameObject.Find(ObjectNames.Player);
            Bullet = ShootingHelper.GetDefaultBullet(Type);
            Barrel = gameObject.GetComponent<Rigidbody2D>();
            Muzzle = Barrel.transform.Find(ObjectNames.Muzzle).gameObject;
            AltMuzzle = Barrel.transform.Find(ObjectNames.AltMuzzle)?.gameObject;
            LastShotFrom = Muzzle;
        }

        void FixedUpdate()
        {
            if (Player == null)
            {
                return;
            }

            // Target Player
            Vector3 playerPosition = Player.transform.position;
            Vector3 currentPosition = Barrel.transform.position;
            Vector2 target = new Vector2(playerPosition.x - currentPosition.x, playerPosition.y - currentPosition.y);

            // Rotate towards player
            if (target.magnitude <= AimRange)
            {
                MovementHelper.Rotate(ref Barrel, target, 90f);
            }

            // Shoot at player
            if (target.magnitude <= ShootRange)
            {
                if (DateTime.Now > LastFire.AddSeconds(ShootingHelper.GetCooldown(Type)))
                {
                    if (LastShotFrom == AltMuzzle || AltMuzzle == null)
                    {
                        ShootingHelper.Shoot(Bullet, Muzzle.transform.position, Barrel.rotation, Type != EntityType.Turret);
                        LastShotFrom = Muzzle;
                    }
                    else
                    {
                        ShootingHelper.Shoot(Bullet, AltMuzzle.transform.position, Barrel.rotation, Type != EntityType.Turret);
                        LastShotFrom = AltMuzzle;
                    }

                    LastFire = DateTime.Now;
                }
            }
        }

        // Update is called once per frame
        void Update() { }
    }
}
