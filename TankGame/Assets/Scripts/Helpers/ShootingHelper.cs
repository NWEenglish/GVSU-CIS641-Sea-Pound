using System.Collections.Generic;
using Assets.Scripts.Names;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class ShootingHelper
    {

        private const float missileSpeed = 500f;
        private const float laserSpeed = 1000f;
        private const double standardCooldown = 1;
        private const double bulletDespawnTimer = 5;

        private static Dictionary<GameObject, System.DateTime> bulletsFired = new Dictionary<GameObject, System.DateTime>();

        public static void Shoot(GameObject bullet, Vector3 spawnLocation, float targetAngle, bool isMissile = true)
        {
            // Create new bullet
            GameObject firedBullet = Object.Instantiate(bullet, spawnLocation, Quaternion.AngleAxis(targetAngle, Vector3.forward));
            firedBullet.GetComponent<Rigidbody2D>().AddForce(GetForceVector(targetAngle, isMissile ? missileSpeed : laserSpeed));
            firedBullet.GetComponent<AudioSource>().volume = 1;
            bulletsFired.Add(firedBullet, System.DateTime.Now);
        }

        public static void CleanUpBullets()
        {
            // Removes bullets after given despawn timer has elapsed
            foreach (var bullet in bulletsFired)
            {
                if (System.DateTime.Now > bullet.Value.AddSeconds(bulletDespawnTimer))
                {
                    Object.Destroy(bullet.Key);
                }
            }
        }

        public static double GetCooldown(EntityType enemyType)
        {
            if (enemyType == EntityType.Turret)
            {
                return ShootingHelper.standardCooldown * (3/4f);
            }
            else
            {
                return ShootingHelper.standardCooldown;
            }
        }

        // Credit to GlassesGuy for the equations to compute this.
        // https://answers.unity.com/questions/1646067/can-you-add-a-force-to-a-rigidbody-at-an-angle.html
        private static Vector2 GetForceVector(float angle, float bulletSpeed)
        {
            float x_component = Mathf.Cos(angle * Mathf.PI / 180) * bulletSpeed;
            float y_component = Mathf.Sin(angle * Mathf.PI / 180) * bulletSpeed;

            Vector2 force = new Vector2(x_component, y_component);

            return force;
        }
    }
}
