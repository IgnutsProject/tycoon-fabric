using System;
using UnityEngine;

namespace Audio.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        [SerializeField] private Sound[] sounds;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            Initialize();

        }

        private void Initialize()
        {
            foreach (Sound sound in sounds)
            {
                sound.AudioSource = gameObject.AddComponent<AudioSource>();
                sound.AudioSource.clip = sound.AudioClip;

                sound.AudioSource.volume = sound.Volume;
                sound.AudioSource.playOnAwake = sound.PlayOnAwake;

                sound.AudioSource.outputAudioMixerGroup = sound.AudioMixerGroup;

                if (sound.PlayOnAwake)
                {
                    sound.AudioSource.Play();
                }
            }
        }

        public void Play(string clipName)
        {
            Array.Find(sounds, sound => sound.Name == clipName).AudioSource.Play();
        }

        public void Stop(string clipName)
        {
            Array.Find(sounds, sound => sound.Name == clipName).AudioSource.Stop();
        }

        public bool IsPlaying(string clipName)
        {
            return Array.Find(sounds, sound => sound.Name == clipName).AudioSource.isPlaying;
        }

        public void SetMusicStatus(bool isOn)
        {
            //audioMixer.audioMixer.SetFloat("Music", isOn ? 0 : -80);
            //audioMixer.audioMixer.GetFloat("Music", out float a);
        }

        public void SetSoundStatus(bool isOn)
        {
            //audioMixer.audioMixer.SetFloat("Sounds", isOn ? 0 : -80);
        }
    }
}
