using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    // Public items to share with Unity
    private const float acceleration = 5f;
    private const float deceleration = -0.95f;
    private const float maxSpeed = 5f;
    private const float rotationSpeed = 100f;

    private Vector2 movement;

    private Rigidbody2D rigidbody_2D;
    private AudioSource audioSource_Idle;
    private AudioSource audioSource_Moving;

    // Start is called before the first frame update
    public void Start()
    {
        // Setup Rigidbody Object
        rigidbody_2D = gameObject.GetComponent<Rigidbody2D>();


        // Setup Audio Objects
        var audioSources = gameObject.GetComponents<AudioSource>();
        audioSource_Idle = audioSources[0];
        audioSource_Moving = audioSources[1];

        audioSource_Moving.loop = true;
        audioSource_Moving.Play();
        audioSource_Moving.volume = 0.2f;

        audioSource_Idle.loop = true;
        audioSource_Idle.Play();
        audioSource_Idle.volume = 0.1f;
    }

    // Updates is called at a fixed interval
    public void FixedUpdate()
    {
        Move();

        // Rotate player
        if (movement != Vector2.zero)
        {
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternion, rotationSpeed);

            // Sprite faces to the right, so need to account for this in movement
            transform.rotation *= Quaternion.Euler(0f, 0f, -90f);
        }
    }

    private void Move()
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

    // Update is called once per frame
    public void Update() 
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal") * acceleration;
        float verticalSpeed = Input.GetAxisRaw("Vertical") * acceleration;

        // Update audio based on acceleration of the player
        if (horizontalSpeed != 0 || verticalSpeed != 0)
        {
            audioSource_Idle.mute = true;
            audioSource_Moving.mute = false;
        }
        else
        {
            audioSource_Idle.mute = false;
            audioSource_Moving.mute = true;
        }
    }
}
