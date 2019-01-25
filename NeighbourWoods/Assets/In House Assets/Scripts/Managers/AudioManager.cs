using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Manager.Player;
namespace Manager.Audio
{
    #region AudioManager Class
    public class AudioManager : Singleton<AudioManager>
    {
        
        public bool hasAudioSource;
        public AudioFiles[] audioFiles;
        
        void Start()
        {
            foreach (AudioFiles a in audioFiles)
            {
                a.audioSource = gameObject.AddComponent<AudioSource>();
                a.audioSource.clip = a.audioClip;
                a.audioSource.volume = a.volume;
                a.audioSource.pitch = a.pitch;
                a.audioSource.loop = a.loop;
                a.audioSource.priority = a.priority;
            }
        }
        public void PlayAudio(string audioName)
        {
            AudioFiles a = Array.Find(audioFiles, audioFiles => audioFiles.audioName == audioName);
            if (a == null)
            {
                Debug.LogWarning("Audio" + audioName + "not found or typo");
                return;
            }
            if (hasAudioSource == true)
            {
                a.audioSource.clip = a.audioClip;
                a.audioSource.volume = a.volume;
                a.audioSource.pitch = a.pitch;
                a.audioSource.loop = a.loop;
                a.audioSource.priority = a.priority;
            }
            hasAudioSource = false;
        }
        public void FindsSoundSource(AudioSource audioSource)
        {
            AudioSource aS = audioSource;
            if (aS == null)
            {
                aS = gameObject.AddComponent<AudioSource>();
                hasAudioSource = false;
            }
            else
            {
                hasAudioSource = true;
            }
        }
        void OnEnable()  //Subscribes to our game events
        {
            GameEvents.OnVisionChange += OnVisionChange;
        }
        void OnDisable() //Unsubscribes to our game events
        {
            GameEvents.OnVisionChange -= OnVisionChange;
        }
        void OnVisionChange(Vision vision)
        {
            Debug.Log("DOG SOUND");

        }
    }
    #endregion
    #region AudioFiles Class
    [System.Serializable]
    public class AudioFiles
    {
        public string audioName;
        public AudioClip audioClip;
        [HideInInspector]
        public AudioSource audioSource;
        public static bool mute;
        public bool loop;
        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;
        [Range(0, 256)]
        public int priority;
    }
    #endregion

}
