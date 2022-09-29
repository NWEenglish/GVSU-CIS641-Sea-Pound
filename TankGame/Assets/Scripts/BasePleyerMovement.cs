using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class BasePleyerMovement
    {
        public void Move()
        {
            float horizontalSpeed = Input.GetAxisRaw("Horizontal") * acceleration;
            float verticalSpeed = Input.GetAxisRaw("Vertical") * acceleration;

            // Accelerate the player
            if (horizontalSpeed != 0 || verticalSpeed != 0)
            {
                movement = new Vector2(horizontalSpeed, verticalSpeed);
                rigidbody_2D.AddForce(movement);
            }

            // Cap player speed
            if (rigidbody_2D.velocity.magnitude > maxSpeed)
            {
                rigidbody_2D.velocity = rigidbody_2D.velocity.normalized * maxSpeed;
            }

            // Decelerate the player
            movement = new Vector2(rigidbody_2D.velocity.x * deceleration, rigidbody_2D.velocity.y * deceleration);
            rigidbody_2D.AddForce(movement);
        }
    }
}
