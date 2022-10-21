using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using TMPro;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
    public GameObject bullet;
    public GameObject barrelMuzzle;
    public GameObject AmmoCount_HUD;

    private Rigidbody2D rigidbody_2D;
    private int AmmoCount;

    private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * MovementHelper.acceleration;
    private float VerticalSpeed => Input.GetAxisRaw("Vertical") * MovementHelper.acceleration;

    private System.DateTime lastShot = System.DateTime.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        // Setup Rigidbody Object
        rigidbody_2D = gameObject.GetComponent<Rigidbody2D>();

        AmmoCount = ShootingHelper.PlayerStartingAmmo;
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
        if (AmmoCount > 0)
        {
            if (Input.GetMouseButtonDown(0) && System.DateTime.Now > lastShot.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player)))
            {
                float bulletTargetAngle = rigidbody_2D.rotation;
                ShootingHelper.Shoot(bullet, barrelMuzzle.transform.position, bulletTargetAngle);
                lastShot = System.DateTime.Now;
                AmmoCount--;

            }
        }

        AmmoCount_HUD.GetComponent<TextMeshProUGUI>().text = $"Ammo: {AmmoCount}";
        if (AmmoCount < 10)
        {
            AmmoCount_HUD.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            AmmoCount_HUD.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
