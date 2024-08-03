using System;
using System.Linq;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using Zenject;

namespace AVPlayer.Media
{
    public class MediaController : ITickable
    {
        public Action VideoLoaded;
        public Action VideoEnded;
        
        private readonly MediaPlayer _mediaPlayer;
        private readonly MediaStorage _mediaStorage;
        private readonly TickableManager _tickableManager;

        private bool _isActive;

        public MediaController(
            MediaPlayer mediaPlayer,
            MediaStorage mediaStorage,
            TickableManager tickableManager)
        {
            _mediaPlayer = mediaPlayer;
            _mediaStorage = mediaStorage;
            _tickableManager = tickableManager;
        }
        
        public bool TryToLoadVideo(string videoName)
        {
            var video = _mediaStorage.GetVideo(videoName);
            if (video == null)
            {
                Debug.LogError($"Video with name: {videoName} didn't found!");
                return false;
            }
            
            _mediaPlayer.OpenMedia(video, false);
            VideoLoaded?.Invoke();
            return true;
        }

        public void PlayVideo()
        {
            if (_mediaPlayer.MediaReference == null)
            {
                TryToLoadVideo(_mediaStorage.GetNames().First());
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
            if (isRunning)
            {
                _tickableManager.Add(this);
                _isActive = true;
            }
            else
            {
                _tickableManager.Remove(this);
                _isActive = false;
            }
        }

        public void Tick()
        {
            if (_mediaPlayer.Control.IsFinished())
            {
                VideoEnded?.Invoke();
            }
        }
    }
}
