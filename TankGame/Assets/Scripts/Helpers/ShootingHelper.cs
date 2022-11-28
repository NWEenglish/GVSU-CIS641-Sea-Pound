using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class ShootingHelper
    {
        private const float MissileSpeed = 500f;
        private const float LaserSpeed = 1000f;
        private const double StandardCooldown = 1;
        private const double BulletDespawnTimer = 3;

        public static void Shoot(GameObject bullet, Vector3 spawnLocation, float targetAngle)
        {
            float speed = bullet.name.Contains(ObjectNames.Missile) ? MissileSpeed : LaserSpeed;

            // Ensure bullet is on level -2 (level of map objects)
            spawnLocation.z = -2;

            // Create new bullet
            GameObject firedBullet = Object.Instantiate(bullet, spawnLocation, Quaternion.AngleAxis(targetAngle, Vector3.forward));
            firedBullet.GetComponent<Rigidbody2D>().AddForce(GetForceVector(targetAngle, speed));
            firedBullet.GetComponent<AudioSource>().volume = 1;
            firedBullet.AddComponent<TimerLogic>().SetLengthOfLife(BulletDespawnTimer);
        }

        public static double GetCooldown(EntityType enemyType)
        {
            if (enemyType == EntityType.Turret)
            {
                return StandardCooldown * (3/4f);
            }
            else
            {
                return StandardCooldown;
            }
        }

        public static GameObject GetDefaultBullet(EntityType type)
        {
            switch (type)
            {
                case EntityType.Turret:
                    return GameObject.Find(ObjectNames.Beam);
                default:
                    return GameObject.Find(ObjectNames.Missile);
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
