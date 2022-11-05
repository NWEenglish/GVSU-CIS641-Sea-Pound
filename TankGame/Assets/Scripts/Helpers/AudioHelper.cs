using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class AudioHelper
    {
        private AudioSource IdleAudio;
        private AudioSource MoveAudio;

        public AudioHelper(AudioSource idleAudio, AudioSource moveSource)
        {
            IdleAudio = idleAudio;
            MoveAudio = moveSource;

            AudioSetup();
        }

        public void PlayAudio(Vector2 acceleration)
        {
            if (acceleration.magnitude == 0)
            {
                IdleAudio.mute = true;
                MoveAudio.mute = false;
            }
            else
            {
                IdleAudio.mute = false;
                MoveAudio.mute = true;
            }
        }

        private void AudioSetup()
        {
            IdleAudio.loop = true;
            IdleAudio.Play();
            IdleAudio.volume = 0.4f;

            MoveAudio.loop = true;
            MoveAudio.Play();
            MoveAudio.volume = 0.2f;
        }
    }
}
