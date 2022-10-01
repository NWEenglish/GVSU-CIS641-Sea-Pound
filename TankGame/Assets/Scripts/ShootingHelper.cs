using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

    public static class ShootingHelper
    {
        public const double bulletDespawnTimer = 5;

        private static Dictionary<GameObject, System.DateTime> bulletsFired = new Dictionary<GameObject, System.DateTime>();

        public static void Shoot(GameObject bullet, Vector3 spawnLocation, float targetAngle)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wsp = Camera.main.WorldToScreenPoint(bullet.transform.position);
            Vector2 target = new Vector2(mousePosition.x - wsp.x, mousePosition.y - wsp.y);

            // Create new bullet
            GameObject firedBullet = Object.Instantiate(bullet, spawnLocation, Quaternion.AngleAxis(targetAngle, Vector3.forward));
            //Rotate(ref firedBullet, target, 90f);

            bulletsFired.Add(firedBullet, System.DateTime.Now);
        }

        public static void CleanUpBullets()
        {
            foreach (var bullet in bulletsFired)
            {
                if (System.DateTime.Now > bullet.Value.AddSeconds(bulletDespawnTimer))
                {
                    Object.Destroy(bullet.Key);
                }
            }
        }

        private static void Rotate(ref GameObject gameObject, Vector2 targetDirection, float correctiveAngle = 0f)
        {
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();

            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, targetDirection);
            rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, quaternion, PlayerHelper.rotationSpeed);

            if (correctiveAngle != 0f)
            {
                rigidbody.transform.rotation *= Quaternion.Euler(0f, 0f, correctiveAngle);
            }
        }
    }
}
