﻿using UnityEngine;

namespace Assets.Scripts
{
    public class ExplosionLogic : MonoBehaviour
    {
        private AudioSource AudioSource;
        private Animator Animator;
        private bool WasInit = false;
        private bool CanPlay = true;
        private bool IsDistantVolume = false;

        private const int Speed = 4;
        private const float DistantVolume = 0.2f;
        private const string PlayAnimation = "Explosion";

        void Start()
        {
            AudioSource = gameObject.GetComponent<AudioSource>();
            Animator = gameObject.GetComponent<Animator>();
            Animator.speed = Speed;
        }

        void Update()
        {
            if (WasInit && CanPlay)
            {
                if (IsDistantVolume)
                {
                    AudioSource.volume = DistantVolume;
                }

                AudioSource.Play();
                Animator.Play(PlayAnimation);
                CanPlay = false;
            }

            if (WasInit && !IsAnimationPlaying())
            {
                Destroy(gameObject);
            }
        }

        public void Init(bool objectDestroyed = false, bool isDespawn = false)
        {
            WasInit = true;
            IsDistantVolume = isDespawn;
            
            if (objectDestroyed)
            {
                gameObject.transform.localScale = new Vector3(8, 8, 1);
            }
        }

        private bool IsAnimationPlaying()
        {
            bool animationPlaying = Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 || Animator.IsInTransition(0);
            bool audioPlaying = AudioSource.isPlaying;

            return animationPlaying && audioPlaying;
        }
    }
}
