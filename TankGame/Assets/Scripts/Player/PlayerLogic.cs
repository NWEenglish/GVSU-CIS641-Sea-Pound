using System;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Names;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerLogic : MonoBehaviour
    {
        private int Ammo;
        private int Health;
        private DateTime LastRegenTime;
        private DateTime LastShotTime;
        private GameObject Ammo_HUD;
        private GameObject Health_HUD;
        private AudioHelper AudioHelper;

        private float HorizontalSpeed => Input.GetAxisRaw("Horizontal") * MovementHelper.acceleration;
        private float VerticalSpeed => Input.GetAxisRaw("Vertical") * MovementHelper.acceleration;

        void Start()
        {
            // We want the player to start with slightly less health
            PlayerStatusHelper.IsPlayerAlive = true;
            Health = HealthHelper.GetMaxHealth(EntityType.Player) - 20;
            Ammo = ShootingHelper.PlayerStartingAmmo;

            LastRegenTime = DateTime.Now;
            LastShotTime = DateTime.Now.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player) * -1);
            Ammo_HUD = GameObject.Find(HUDNames.Ammo);
            Health_HUD = GameObject.Find(HUDNames.Health);

            AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
            AudioHelper = new AudioHelper(audioSources[0], audioSources[1]);
        }

        void FixedUpdate()
        {
            AudioHelper.PlayAudio(new Vector2(HorizontalSpeed, VerticalSpeed));
        }

        void Update()
        {
            AmmoUpdate();
            HealthUpdate();
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

        private void AmmoUpdate()
        {
            // Update Ammo status
            if (Ammo > 0 && DateTime.Now > LastShotTime.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player)))
            {
                PlayerStatusHelper.CanShoot = true;
            }
            else
            {
                PlayerStatusHelper.CanShoot = false;
            }

            // Shoot bullet
            if (Input.GetMouseButtonDown(0) && PlayerStatusHelper.CanShoot)
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
    }
}
