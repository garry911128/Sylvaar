using System.Collections;
using Audio;
using Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace UI
{
    public class EndSceneUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject goodEndUI;
        [SerializeField] private GameObject badEndUI;
        [SerializeField] private GameObject EndMenu;
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private RawImage videoDisplay;

        void Start()
        {
            EndMenu.SetActive(false);
            videoPlayer.targetCamera = UnityEngine.Camera.main;
            videoPlayer.SetDirectAudioVolume(0, AudioManager.Instance.GetVolumn());
            
            if (videoPlayer == null)
            {
                //Debug.LogError("No VideoPlayer component found on this GameObject.");
                return;
            }

            
            videoPlayer.loopPointReached += OnVideoEnd;

            
            bool isGoodEnd = GameManager.Instance.isGoodEnd;
            Play(isGoodEnd);

            
            goodEndUI.SetActive(false);
            badEndUI.SetActive(false);
        }

        public void Play(bool isGoodEnd)
        {
            string videoPath = isGoodEnd ? "Video/GoodEnding" : "Video/BadEnding";

            VideoClip videoClip = Resources.Load<VideoClip>(videoPath);

            if (videoClip != null)
            {
                //Debug.Log($"Playing video clip: {videoClip.name}");
                videoPlayer.clip = videoClip;
                videoPlayer.Play();
            }
            else
            {
                //Debug.LogError($"Video clip not found at Resources/{videoPath}");
            }
        }

        private void OnVideoEnd(VideoPlayer vp)
        {
            videoDisplay.gameObject.SetActive(false);
            EndMenu.SetActive(true);
            if (GameManager.Instance.isGoodEnd)
            {
                goodEndUI.SetActive(true);
                badEndUI.SetActive(false);
                AudioManager.Instance.PlayOther("GoodEnding");
            }
            else
            {
                goodEndUI.SetActive(false);
                badEndUI.SetActive(true);
                AudioManager.Instance.PlayOther("BadEnding");
            }

            //Debug.Log("Video has ended. Displaying the ending UI.");
        }

        private void OnDestroy()
        {
            if (videoPlayer != null)
            {
                videoPlayer.loopPointReached -= OnVideoEnd;
            }
        }
    }
}
