using System;
using AVPlayer.Media;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.UIService;
using AVPlayer.UI.UIService.Interfaces;
using UnityEngine;

namespace AVPlayer.UI.Playback
{
    public class PlaybackController : IDisplayController
    {
        private readonly IUIService _uiService;
        private readonly MediaController _mediaController;
        
        private PlaybackView _playbackView;

        public PlaybackController(
            IUIService uiService,
            MediaController mediaController)
        {
            _uiService = uiService;
            _mediaController = mediaController;
        }
        
        public void ShowComponent()
        {
            _playbackView = _uiService.Get<PlaybackView>();
            
            _playbackView.OnPlayButtonClickEvent += PlayClicked;
            _playbackView.OnPauseButtonClickEvent += PauseClicked;

            _mediaController.VideoLoaded += PauseWithoutNotification;
            _mediaController.VideoEnded += PauseWithoutNotification;
            
            _uiService.Show<PlaybackView>();
        }

        private void PlayClicked()
        {
            _mediaController.PlayVideo();
        }

        private void PauseClicked()
        {
            _mediaController.StopVideo();
        }

        private void PauseWithoutNotification()
        {
            _playbackView.SetPauseWithoutNotification();
        }

        public void HideComponent()
        {
            _playbackView.OnPlayButtonClickEvent -= PlayClicked;
            _playbackView.OnPauseButtonClickEvent -= PauseClicked;
            
            _mediaController.VideoLoaded -= PauseClicked;
            _mediaController.VideoEnded -= PauseClicked;
            
            _uiService.Hide<PlaybackView>();
        }

        
    }
}
