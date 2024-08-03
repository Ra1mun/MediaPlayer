using System;
using AVPlayer.Media;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.UIService;

namespace AVPlayer.UI.Playback
{
    public class PlaybackController : IDisplayController
    {
        private readonly PlaybackView _playbackView;
        private readonly UIService.UIService _uiService;
        private readonly MediaController _mediaController;

        public PlaybackController(
            UIService.UIService uiService,
            MediaController mediaController)
        {
            _uiService = uiService;
            _mediaController = mediaController;

            _playbackView = _uiService.Get<PlaybackView>();
        }
        
        public void ShowComponent()
        {
            _playbackView.OnPlayButtonClickEvent += PlayClicked;
            _playbackView.OnPauseButtonClickEvent += PauseClicked;

            _mediaController.VideoLoaded += PauseClicked;
            _mediaController.VideoEnded += PauseClicked;
            
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
