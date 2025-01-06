using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.Properties;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        [SerializeField] private AudioSource bgmAudioSource;
        [SerializeField] private AudioSource attackAudioSource;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


        public void SetVolumn(float volume)
        {
            bgmAudioSource.volume = volume;
            attackAudioSource.volume = volume;
        }

        public float GetVolumn()
        {
            return bgmAudioSource.volume;
        }

        public void PlayBGM()
        {
            bgmAudioSource.Play();
        }

        public void PlayOther(String otherName)
        {
            AudioClip audioClip = Resources.Load<AudioClip>($"Audio/{otherName}");
            attackAudioSource.clip = audioClip;
            attackAudioSource.Play();
        }


        public void Stop()
        {
            bgmAudioSource.Stop();
        }
    }
}
