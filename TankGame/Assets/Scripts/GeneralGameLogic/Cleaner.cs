using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.GeneralGameLogic
{
    public class Cleaner : MonoBehaviour
    {
        void Update()
        {
            ShootingHelper.CleanUpBullets();
        }
    }
}
