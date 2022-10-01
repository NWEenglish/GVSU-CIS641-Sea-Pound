using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ShootingHelper
    {
        private const double bulletDespawnTimer = 5;

        private static Dictionary<GameObject, System.DateTime> bulletsFired = new Dictionary<GameObject, System.DateTime>();

        public static void Shoot(GameObject bullet, Vector3 spawnLocation, float targetAngle)
        {
            // Create new bullet
            GameObject firedBullet = Object.Instantiate(bullet, spawnLocation, Quaternion.AngleAxis(targetAngle, Vector3.forward));
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
    }
}
