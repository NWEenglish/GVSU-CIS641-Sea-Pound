using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerLogic : MonoBehaviour
    {
        private AudioHelper AudioHelper;
        private PlayerStatus PlayerStatus;

        private GameObject Ammo_HUD;
        private GameObject Health_HUD;
        private GameObject Muzzle;
        private GameObject Bullet;

        private Rigidbody2D Body;
        private Rigidbody2D Barrel;

        private const float Acceleration = 5f;
        private const float MaxSpeed = 5f;
        private const int AmmoDangerZone = 10;
        private const int HealthDangerZone = 50;

        private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * Acceleration;
        private float VerticalSpeed => Input.GetAxisRaw("Vertical") * Acceleration;

        void Start()
        {
            // Set starting stats
            PlayerStatus = new PlayerStatus();
            
            // Set HUDs
            Ammo_HUD = GameObject.Find(HUDNames.Ammo);
            Health_HUD = GameObject.Find(HUDNames.Health);

            // Set audio sources
            AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
            AudioHelper = new AudioHelper(audioSources[0], audioSources[1], 0.3f);

            // Set player components and game objects
            Body = gameObject.GetComponent<Rigidbody2D>();
            Barrel = gameObject.transform.Find(ObjectNames.Barrel).GetComponent<Rigidbody2D>();
            Muzzle = Barrel.transform.Find(ObjectNames.Muzzle).gameObject;
            Bullet = ShootingHelper.GetDefaultBullet(EntityType.Player);
        }

        void FixedUpdate()
        {
            AudioHelper.PlayAudio(new Vector2(HorizontalSpeed, VerticalSpeed));
            MovePlayer();
            AimBarrel();
        }

        void Update()
        {
            AmmoUpdate();
            HealthUpdate();
            ShootUpdate();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerStatus.OnCollision(collision);
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.name.Contains(CollidableObjectNames.HomeBase))
            {
                PlayerStatus.OnRegen();
            }
        }

        private void MovePlayer()
        {
            // Moves player
            Vector2 movement = MovementHelper.Move(ref Body, HorizontalSpeed, VerticalSpeed, MaxSpeed);

            // Rotate player
            MovementHelper.Rotate(ref Body, movement, -90f);

            if (MovementHelper.IsOutOfBounds(gameObject))
            {
                gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z);
            }
        }

        private void AimBarrel()
        {
            // Rotate barrel
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wsp = Camera.main.WorldToScreenPoint(Barrel.transform.position);
            Vector2 target = new Vector2(mousePosition.x - wsp.x, mousePosition.y - wsp.y);

            MovementHelper.Rotate(ref Barrel, target, 90f);
        }

        private void AmmoUpdate()
        {
            // Update Ammo HUD
            Ammo_HUD.GetComponent<TextMeshProUGUI>().text = $"Ammo: {PlayerStatus.Ammo}";
            if (PlayerStatus.Ammo < AmmoDangerZone)
            {
                Ammo_HUD.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Ammo_HUD.GetComponent<TextMeshProUGUI>().color = Color.white;
            }
        }

        private void HealthUpdate()
        {
            Health_HUD.GetComponent<TextMeshProUGUI>().text = $"Health: {PlayerStatus.Health}";
            if (PlayerStatus.Health < HealthDangerZone)
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.white;
            }

            if (!PlayerStatus.IsAlive)
            {
                Instantiate(GameObject.Find(ObjectNames.Explosion), gameObject.transform.position, new Quaternion()).GetComponent<ExplosionLogic>().Init(true);
                Destroy(gameObject);
            }
        }

        private void ShootUpdate()
        {
            // Shoot bullet
            if (Input.GetMouseButtonDown(0))
            {
                bool wasSuccessful = PlayerStatus.RegisterShot();

                if (wasSuccessful)
                {
                    float bulletTargetAngle = Barrel.rotation;
                    ShootingHelper.Shoot(Bullet, Muzzle.transform.position, bulletTargetAngle);
                }
            }
        }
    }
}
