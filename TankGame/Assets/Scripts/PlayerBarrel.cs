using Assets.Scripts;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrelMuzzle;

    private Rigidbody2D rigidbody_2D;

    private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * PlayerHelper.acceleration;
    private float VerticalSpeed => Input.GetAxisRaw("Vertical") * PlayerHelper.acceleration;

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
        PlayerHelper.Move(ref rigidbody_2D, HorizontalSpeed, VerticalSpeed);

        // Rotate barrel
        Vector3 mousePosition = Input.mousePosition;
        Vector3 wsp = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 target = new Vector2(mousePosition.x - wsp.x, mousePosition.y - wsp.y);

        PlayerHelper.Rotate(ref rigidbody_2D, target, 90f);

        // Shoot bullet
        float bulletTargetAngle = rigidbody_2D.rotation;
        ShootingHelper.Shoot(bullet, barrelMuzzle.transform.position, bulletTargetAngle);
        ShootingHelper.CleanUpBullets();
    }

    // Update is called once per frame
    void Update() { }
    
}
