using UnityEngine;

namespace Assets.Scripts
{
    public static class PlayerHelper
    {
        public const float acceleration = 5f;
        public const float deceleration = -0.95f;
        public const float maxSpeed = 5f;
        public const float rotationSpeed = 100f;

        public static Vector2 Move(ref Rigidbody2D rigidbody, float horizontalSpeed, float verticalSpeed)
        {
            Vector2 movement;

            // Accelerate the player
            if (horizontalSpeed != 0 || verticalSpeed != 0)
            {
                movement = new Vector2(horizontalSpeed, verticalSpeed);
                rigidbody.AddForce(movement);
            }

            // Cap player speed
            if (rigidbody.velocity.magnitude > maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }

            // Decelerate the player
            movement = new Vector2(rigidbody.velocity.x * deceleration, rigidbody.velocity.y * deceleration);
            rigidbody.AddForce(movement);

            return movement;
        }

        public static void Rotate(ref Rigidbody2D rigidbody, Vector3 target, float correctiveAngle = 0f)
        {
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, target);
            rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, quaternion, PlayerHelper.rotationSpeed);

            if (correctiveAngle != 0f)
            {
                rigidbody.transform.rotation *= Quaternion.Euler(0f, 0f, correctiveAngle);
            }
        }
    }
}
