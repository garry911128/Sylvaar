using Audio;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class VolumeController : MonoBehaviour
    {
        public Slider volumeSlider; 
        private float currentVolume = 0.5f;

        void Start()
        {
            if (volumeSlider != null)
            {
                volumeSlider.value = currentVolume;
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }

            SetVolume(currentVolume);
        }

        public void SetVolume(float volume)
        {
            currentVolume = volume;
            AudioListener.volume = currentVolume;
            AudioManager.Instance.SetVolumn(currentVolume);
        }
    }

}