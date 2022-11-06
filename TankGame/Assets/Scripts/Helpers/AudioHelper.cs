using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class AudioHelper
    {
        private AudioSource IdleAudio;
        private AudioSource MoveAudio;

        public AudioHelper(AudioSource idleAudio, AudioSource moveSource, float volume)
        {
            IdleAudio = idleAudio;
            MoveAudio = moveSource;

            AudioSetup(volume);
        }

        public void PlayAudio(Vector2 acceleration)
        {
            if (acceleration.magnitude == 0)
            {
                IdleAudio.mute = false;
                MoveAudio.mute = true;
            }
            else
            {
                IdleAudio.mute = true;
                MoveAudio.mute = false;
            }
        }

        public void MuteAudio()
        {
            IdleAudio.mute = true;
            MoveAudio.mute = true;
        }

        private void AudioSetup(float volume)
        {
            IdleAudio.loop = true;
            IdleAudio.Play();
            IdleAudio.volume = volume / 2f;

            MoveAudio.loop = true;
            MoveAudio.Play();
            MoveAudio.volume = volume;
        }
    }
}
