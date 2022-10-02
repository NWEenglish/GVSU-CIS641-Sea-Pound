using Assets.Scripts.Helpers;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootingHelper.CleanUpBullets();
    }
}
