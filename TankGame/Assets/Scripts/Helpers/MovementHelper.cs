using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class MovementHelper
    {
        public const float acceleration = 5f;
        public const float deceleration = -0.95f;
        public const float maxSpeed = 5f;
        public const float rotationSpeed = 100f;

        public static Vector2 Move(ref Rigidbody2D rigidbody, float horizontalSpeed, float verticalSpeed, float? maxSpeedOverride = null)
        {
            Vector2 movement;

            // Accelerate the entity
            if (horizontalSpeed != 0 || verticalSpeed != 0)
            {
                movement = new Vector2(horizontalSpeed, verticalSpeed);
                rigidbody.AddForce(movement);
            }

            // Cap entity speed
            if (maxSpeedOverride.HasValue && rigidbody.velocity.magnitude > maxSpeedOverride.Value)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeedOverride.Value;
            }
            else if (rigidbody.velocity.magnitude > maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }

            // Decelerate the entity
            movement = new Vector2(rigidbody.velocity.x * deceleration, rigidbody.velocity.y * deceleration);
            rigidbody.AddForce(movement);

            return movement;
        }

        public static void Rotate(ref Rigidbody2D rigidbody, Vector3 target, float correctiveAngle = 0f)
        {
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, target);
            rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, quaternion, MovementHelper.rotationSpeed);

            if (correctiveAngle != 0f)
            {
                rigidbody.transform.rotation *= Quaternion.Euler(0f, 0f, correctiveAngle);
            }
        }
    }
}
