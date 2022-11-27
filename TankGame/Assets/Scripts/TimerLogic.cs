using System;
using Assets.Scripts.Constants.Names;
using UnityEngine;

namespace Assets.Scripts
{
    public class TimerLogic : MonoBehaviour
    {
        private DateTime SpawnTime = DateTime.Now;
        private double? LengthOfLife;

        void Update()
        {
            DestroyIfExpired();
        }

        public void SetLengthOfLife(double lengthOfLife)
        {
            LengthOfLife = lengthOfLife;
        }

        private bool IsExpired()
        {
            if (!LengthOfLife.HasValue)
            {
                return false;
            }
            
            return SpawnTime.AddSeconds(LengthOfLife.Value) < DateTime.Now;
        }

        private void DestroyIfExpired()
        {
            if (IsExpired())
{
                Instantiate(GameObject.Find(ObjectNames.Explosion), gameObject.transform.position, new Quaternion()).GetComponent<ExplosionLogic>().Init(false, true);
                Destroy(gameObject);
            }
        }
    }
}
