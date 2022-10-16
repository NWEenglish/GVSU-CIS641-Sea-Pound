using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrelMuzzle;

    private Rigidbody2D rigidbody_2D;

    private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * MovementHelper.acceleration;
    private float VerticalSpeed => Input.GetAxisRaw("Vertical") * MovementHelper.acceleration;

    private System.DateTime lastShot = System.DateTime.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        // Setup Rigidbody Object
        rigidbody_2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Updates is called at a fixed interval
    private void FixedUpdate()
    {
        // Moves player
        MovementHelper.Move(ref rigidbody_2D, HorizontalSpeed, VerticalSpeed);

        // Rotate barrel
        Vector3 mousePosition = Input.mousePosition;
        Vector3 wsp = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 target = new Vector2(mousePosition.x - wsp.x, mousePosition.y - wsp.y);

        MovementHelper.Rotate(ref rigidbody_2D, target, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot bullet
        if (Input.GetMouseButtonDown(0) && System.DateTime.Now > lastShot.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player)))
        { 
            float bulletTargetAngle = rigidbody_2D.rotation;
            ShootingHelper.Shoot(bullet, barrelMuzzle.transform.position, bulletTargetAngle);
            lastShot = System.DateTime.Now;
        }
    }
}
