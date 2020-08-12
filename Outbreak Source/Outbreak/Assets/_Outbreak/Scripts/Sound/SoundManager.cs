using System.Collections;
using UnityEngine;

namespace Outbreak.Sound
{
    public enum SoundEffect
    {
        Sowrd,
        WallDamage,
        EnemyDeath,
    };

    public class SoundManager : SingletonBehaviour<SoundManager>
    {
        public AudioSource musicSource;
        public AudioSource effectsSource;
        public AudioClip[] Clips;

        private void Start()
        {
            PlayMusic();
        }

        public void PlayMusic()
        {
            musicSource.Play();
        }

        public void PauseMusic(bool isPause)
        {
            if(isPause)
            {
                musicSource.Pause();
            }
            else
            {
                musicSource.UnPause();
            }
        }

        public void PlaySoundEffect(SoundEffect sound)
        {
            effectsSource.PlayOneShot(Clips[(int)sound]);
        }

        public void PlaySoundEffectDelay(SoundEffect sound, float delay)
        {
            StartCoroutine(DelayEffect(sound, delay));
        }

        IEnumerator DelayEffect(SoundEffect sound, float delay)
        {
            yield return new WaitForSeconds(delay);
            effectsSource.PlayOneShot(Clips[(int)sound]);
        }
    }
}