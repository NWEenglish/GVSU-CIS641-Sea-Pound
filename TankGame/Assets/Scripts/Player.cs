using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Public items to share with Unity
    private const float acceleration = 5f;
    private const float deceleration = -0.95f;
    private const float maxSpeed = 5f;
    private const float rotationSpeed = 100f;

    private Rigidbody2D rigidbody_2D;

    // Start is called before the first frame update
    public void Start()
    {
        // Create the Rigidbody
        rigidbody_2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Updates is called at a fixed interval
    public void FixedUpdate()
    {
        Vector2 movement;

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

        // Rotate player
        if (movement != Vector2.zero)
        {
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternion, rotationSpeed);

            // Sprite faces to the right, so need to account for this in movement
            transform.rotation *= Quaternion.Euler(0f, 0f, -90f);
        }
    }

    // Update is called once per frame
    public void Update() { }
}
