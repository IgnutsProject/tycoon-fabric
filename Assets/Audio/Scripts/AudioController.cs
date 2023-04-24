using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio.Scripts
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance { get; private set; }
        
        [SerializeField] private AudioMixer audioMixer;
        
        private float _musicVolume = 1;
        private float _generalVolume = 1;
        
        public float MusicVolume
        {
            get => _musicVolume;
            set
            {
                _musicVolume = value;

                audioMixer.SetFloat(AudioConfig.MusicGroupKey, _musicVolume);
            }
        }
        
        public float GeneralVolume
        {
            get => _generalVolume;
            set
            {
                _generalVolume = value;
                
                audioMixer.SetFloat(AudioConfig.GeneralGroupKey, _generalVolume);
            }
        }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}
