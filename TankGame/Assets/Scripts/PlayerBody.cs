using Assets.Scripts.Helpers;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    private Rigidbody2D rigidbody_2D;
    private AudioSource audioSource_Idle;
    private AudioSource audioSource_Moving;

    //private PlayerHelper playerHelper;
    private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * PlayerHelper.acceleration;
    private float VerticalSpeed => Input.GetAxisRaw("Vertical") * PlayerHelper.acceleration;


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
        // Moves player
        Vector2 movement = PlayerHelper.Move(ref rigidbody_2D, HorizontalSpeed, VerticalSpeed);

        // Rotate player
        if (movement != Vector2.zero)
        {
            PlayerHelper.Rotate(ref rigidbody_2D, movement, -90f);
        }
    }

    // Update is called once per frame
    public void Update() 
    {
        // Update audio based on acceleration of the player
        if (HorizontalSpeed != 0 || VerticalSpeed != 0)
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
