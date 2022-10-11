using System;
using Assets.Scripts.Helpers;
using UnityEngine;

public class EnemyShootingLogic : MonoBehaviour
{
    public float AimRange = 15f;
    public float ShootRange = 12f;

    public GameObject Player;
    public GameObject Muzzle;
    public GameObject Bullet;

    private Rigidbody2D BarrelPivot;
    private DateTime LastFire = DateTime.Now; 

    // Start is called before the first frame update
    void Start()
    {
        BarrelPivot = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Target Player
        Vector3 playerPosition = Player.transform.position;
        Vector3 currentPosition = BarrelPivot.transform.position;
        Vector2 target = new Vector2(playerPosition.x - currentPosition.x, playerPosition.y - currentPosition.y);

        // Rotate towards player
        if (target.magnitude <= AimRange)
        {
            MovementHelper.Rotate(ref BarrelPivot, target, 90f);
        }

        // Shoot at player
        if (target.magnitude <= ShootRange)
        {
            if (DateTime.Now > LastFire.AddSeconds(ShootingHelper.Cooldown))
            {
                ShootingHelper.Shoot(Bullet, Muzzle.transform.position, BarrelPivot.rotation);
                LastFire = DateTime.Now;
            }
        }
    }

    // Update is called once per frame
    void Update() { }
}
