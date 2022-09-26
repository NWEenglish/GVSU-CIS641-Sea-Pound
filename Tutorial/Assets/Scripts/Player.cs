// https://www.gamedevelopment.blog/unity-2d-game-tutorial-2019-player-movement/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float hitPoints = 100f;
    public float maxSpeed = 5f;
    public float currentVelocity = 0f;

    private Rigidbody2D rb;
    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Player::Start cant find RigidBody2D </sadface>");
        }
    }

    // this is called at a fixed interval for use with physics objects like the RigidBody2D
    void FixedUpdate()
    {
        Vector2 directionOfMovement;

        // check if user has pressed some input keys
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {

            // convert user input into world movement
            horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
            verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed;

            //assign world movements to a Veoctor2
            directionOfMovement = new Vector2(horizontalMovement, verticalMovement);

            // apply movement to player's transform
            rb.AddForce(directionOfMovement); 
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Slow down player gradually
        rb.AddForce(new Vector2(rb.velocity.x * -0.95f, rb.velocity.y * -0.95f));

        currentVelocity = rb.velocity.magnitude;
    }

    // Update is called once per frame
    void Update() { }
}
