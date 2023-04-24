using System;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.Scripts
{
    public class MainMenuAudioManagerView : AudioManagerView
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider generalSlider;

        protected override void Start()
        {
            base.Start();
            
            musicSlider.onValueChanged.AddListener(value =>
            {
                AudioController.Instance.MusicVolume = value * -80;
            });
            
            generalSlider.onValueChanged.AddListener(value =>
            {
                AudioController.Instance.GeneralVolume = value * -80;
            });
        }
    }
}