using System;
using Assets.Scripts.Constants.Names;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.Helpers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerLogic : MonoBehaviour
    {
        private int Ammo;
        private int Health;
        private bool CanShoot;
        private DateTime LastRegenTime;
        private DateTime LastShotTime;
        private AudioHelper AudioHelper;
        
        private GameObject Ammo_HUD;
        private GameObject Health_HUD;
        private GameObject Muzzle;
        private GameObject Bullet;

        private Rigidbody2D Body;
        private Rigidbody2D Barrel;

        private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * MovementHelper.acceleration;
        private float VerticalSpeed => Input.GetAxisRaw("Vertical") * MovementHelper.acceleration;

        void Start()
        {
            // Set starting stats
            PlayerStatusHelper.IsPlayerAlive = true;
            Health = HealthHelper.GetMaxHealth(EntityType.Player) - 20;
            Ammo = ShootingHelper.PlayerStartingAmmo;

            // Set starting timers
            LastRegenTime = DateTime.Now;
            LastShotTime = DateTime.Now.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player) * -1);
            
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
            DamageHelper.CalculateHealthOnCollision(ref Health, collision);
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.name.Contains(CollidableObjectNames.HomeBase))
            {
                if (LastRegenTime.AddSeconds(0.20) < DateTime.Now)
                {
                    if (Health < HealthHelper.GetMaxHealth(EntityType.Player))
                    {
                        Health++;
                    }

                    if (Ammo < ShootingHelper.PlayerMaxAmmo)
                    {
                        Ammo++;
                    }

                    LastRegenTime = DateTime.Now;
                }
            }
        }

        private void MovePlayer()
        {
            // Moves player
            Vector2 movement = MovementHelper.Move(ref Body, HorizontalSpeed, VerticalSpeed);

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
            Vector3 wsp = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 target = new Vector2(mousePosition.x - wsp.x, mousePosition.y - wsp.y);

            MovementHelper.Rotate(ref Barrel, target, 90f);
        }

        private void AmmoUpdate()
        {
            // Update Ammo status
            if (Ammo > 0 && DateTime.Now > LastShotTime.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player)))
            {
                CanShoot = true;
            }
            else
            {
                CanShoot = false;
            }

            // Shoot bullet
            if (Input.GetMouseButtonDown(0) && CanShoot)
            {
                LastShotTime = DateTime.Now;
                Ammo--;
            }

            // Update Ammo HUD
            Ammo_HUD.GetComponent<TextMeshProUGUI>().text = $"Ammo: {Ammo}";
            if (Ammo < ShootingHelper.PlayerDangerZoneAmmo)
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
            if (Health < 0)
            {
                Health = 0;
            }

            Health_HUD.GetComponent<TextMeshProUGUI>().text = $"Health: {Health}";
            if (Health < HealthHelper.GetPlayerDangerZone)
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
            else
            {
                Health_HUD.GetComponent<TextMeshProUGUI>().color = Color.white;
            }

            if (Health == 0)
            {
                PlayerStatusHelper.IsPlayerAlive = false;
                Destroy(gameObject);
            }
        }

        private void ShootUpdate()
        {
            // Shoot bullet
            if (Input.GetMouseButtonDown(0) && CanShoot)
            {
                float bulletTargetAngle = Barrel.rotation;
                ShootingHelper.Shoot(Bullet, Muzzle.transform.position, bulletTargetAngle);
            }
        }
    }
}
