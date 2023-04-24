using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    [System.Serializable]
    public class Sound
    {
        [Header("General properties")]
        [SerializeField] private string name;
        [SerializeField] private bool playOnAwake;
        
        [Range(0f, 1f)] [SerializeField] 
        private float volume = 1;

        [Header("Audio properties")]
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private AudioMixerGroup audioMixerGroup;

        public string Name => name;
        public bool PlayOnAwake => playOnAwake;
        public float Volume => volume;

        public AudioClip AudioClip => audioClip;
        public AudioMixerGroup AudioMixerGroup => audioMixerGroup;
        
        public AudioSource AudioSource { get; set; }
    }
}
