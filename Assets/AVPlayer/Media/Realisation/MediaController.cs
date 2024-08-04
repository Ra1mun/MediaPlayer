using System;
using System.Linq;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using Zenject;
using AVPlayer.Media.Interfaces;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.Media.Realisation
{
    public class MediaController : ITickable, IMediaController
    {
        public Action VideoLoaded { get; set; }
        public Action VideoEnded { get; set; }
        
        private readonly MediaPlayer _mediaPlayer;
        private readonly IMediaStorage _mediaStorage;
        private readonly IUIRoot _uiRoot;
        private readonly TickableManager _tickableManager;

        private bool _isActive;

        public MediaController(
            MediaPlayer mediaPlayer,
            IMediaStorage mediaStorage,
            IUIRoot uiRoot,
            TickableManager tickableManager)
        {
            _mediaPlayer = mediaPlayer;
            _mediaStorage = mediaStorage;
            _uiRoot = uiRoot;
            _tickableManager = tickableManager;
        }

        public bool TryToLoadVideo(string mediaName, bool autoPlay = false)
        {
            if (string.IsNullOrWhiteSpace(mediaName))
            {
                Debug.LogError("Data of video didn't receive");
            }
            
            var video = _mediaStorage.GetVideo(mediaName);
            if (video == null)
            {
                Debug.LogError($"Video with name: {mediaName} didn't found!");
                return false;
            }
            
            _mediaPlayer.OpenMedia(video, autoPlay);
            _uiRoot.Display.MediaHeaderText = mediaName;
            if (autoPlay)
            {
                return true;
            }
            
            VideoLoaded?.Invoke();
            SetStateVideo(false);
            return true;
        }

        public void PlayVideo()
        {
            if (_mediaPlayer.MediaReference == null && !TryToLoadVideo(_mediaStorage.GetNames().First(), true))
            {
                return;
            }
            
            SetStateVideo(true);
            
            _mediaPlayer.Play();
        }
    
        public void StopVideo()
        {
            SetStateVideo(false);
            
            _mediaPlayer.Stop();
        }
        
        private void SetStateVideo(bool isRunning)
        {
            if (isRunning && !_isActive)
            {
                _tickableManager.Add(this);
                _isActive = true;
            }
            else if(!isRunning && _isActive)
            {
                _tickableManager.Remove(this);
                _isActive = false;
            }
        }

        public void Tick()
        {
            if (_mediaPlayer.Control.IsFinished())
            {
                SetStateVideo(false);
                VideoEnded?.Invoke();
            }
        }
    }
}
