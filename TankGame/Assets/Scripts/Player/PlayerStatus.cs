using System;
using Assets.Scripts.Constants.Types;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStatus
    {
        public bool IsAlive { get; private set; }
        public int Health { get; private set; }
        public int Ammo { get; private set; }
        public bool CanShoot => CheckCanShoot();

        private DateTime LastShotTime;
        private DateTime LastRegenTime;

        private const int PlayerStartingAmmo = 45;
        private const int PlayerMaxAmmo = 50;

        public PlayerStatus()
        {
            IsAlive = true;

            Health = HealthHelper.GetMaxHealth(EntityType.Player) - 20;
            Ammo = PlayerStartingAmmo;

            LastShotTime = DateTime.Now.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player) * -1);
            LastRegenTime = DateTime.Now;
        }

        public void OnCollision(Collision2D collision)
        {
            Health = DamageHelper.CalculateHealthOnCollision(Health, collision);

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void OnRegen()
        {
            if (LastRegenTime.AddSeconds(0.20) < DateTime.Now)
            {
                if (Health < HealthHelper.GetMaxHealth(EntityType.Player))
                {
                    Health++;
                }

                if (Ammo < PlayerMaxAmmo)
                {
                    Ammo++;
                }

                LastRegenTime = DateTime.Now;
            }
        }

        public bool RegisterShot()
        {
            bool successfulShot = false;

            if (CanShoot)
            {
                Ammo--;
                LastShotTime = DateTime.Now;
                successfulShot = true;
            }

            return successfulShot;
        }

        private bool CheckCanShoot()
        {
            if (Ammo > 0 && DateTime.Now > LastShotTime.AddSeconds(ShootingHelper.GetCooldown(EntityType.Player)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
