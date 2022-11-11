using UnityEngine;

namespace Assets.Scripts
{
    public class ExplosionLogic : MonoBehaviour
    {
        private AudioSource AudioSource;
        private Animator Animator;
        private bool wasInit = false;
        private bool canPlay = true;

        private const int Speed = 4;
        private const string PlayAnimation = "Explosion";

        void Start()
        {
            AudioSource = gameObject.GetComponent<AudioSource>();
            Animator = gameObject.GetComponent<Animator>();
            Animator.speed = Speed;
        }

        void Update()
        {
            if (wasInit && canPlay)
            {
                AudioSource.Play();
                Animator.Play(PlayAnimation);
                canPlay = false;
            }

            if (wasInit && !IsAnimationPlaying())
            {
                Destroy(gameObject);
            }
        }

        public void Init()
        {
            wasInit = true;
        }

        private bool IsAnimationPlaying()
        {
            bool animationPlaying = Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 || Animator.IsInTransition(0);
            bool audioPlaying = AudioSource.isPlaying;

            return animationPlaying && audioPlaying;
        }
    }
}
