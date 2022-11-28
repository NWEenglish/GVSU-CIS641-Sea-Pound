using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class MovementHelper
    {
        private const float Deceleration = -0.95f;
        private const float RotationSpeed = 100f;
        private const float OutOfBounds = 200f;

        public static bool IsOutOfBounds(GameObject gameObject)
        {
            if (Mathf.Abs(gameObject.transform.position.x) > OutOfBounds || Mathf.Abs(gameObject.transform.position.y) > OutOfBounds)
            {
                return true;
            }

            return false;
        }

        public static Vector2 Move(ref Rigidbody2D rigidbody, float horizontalSpeed, float verticalSpeed, float maxSpeed)
        {
            Vector2 movement;

            // Accelerate the entity
            if (horizontalSpeed != 0 || verticalSpeed != 0)
            {
                movement = new Vector2(horizontalSpeed, verticalSpeed);
                rigidbody.AddForce(movement);
            }

            // Cap entity speed
            if (rigidbody.velocity.magnitude > maxSpeed)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            }

            // Decelerate the entity
            movement = new Vector2(rigidbody.velocity.x * Deceleration, rigidbody.velocity.y * Deceleration);
            rigidbody.AddForce(movement);

            return movement;
        }

        public static void Rotate(ref Rigidbody2D rigidbody, Vector3 target, float correctiveAngle = 0f)
        {
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, target);
            rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, quaternion, RotationSpeed);

            if (correctiveAngle != 0f)
            {
                rigidbody.transform.rotation *= Quaternion.Euler(0f, 0f, correctiveAngle);
            }
        }
    }
}
