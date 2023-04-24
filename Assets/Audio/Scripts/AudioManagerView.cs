using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Audio.Scripts
{
    public class AudioManagerView : MonoBehaviour
    {
        [SerializeField] private Button[] useButtons;

        protected virtual void Start()
        {
            if (AudioManager.Instance == null)
            {
                Debug.Log("Can`t add sound to the objects!");
                return;
            }
            
            foreach (var button in useButtons)
            {
                button.onClick.AddListener(() =>
                {
                    AudioManager.Instance.Play(AudioConfig.ClickSoundKey);
                });
            }
        }
    }
}
