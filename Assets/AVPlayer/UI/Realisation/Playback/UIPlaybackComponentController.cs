using AVPlayer.Media.Interfaces;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.UI.Realisation.Playback
{
    public class UIPlaybackComponentController : IDisplayComponentController
    {
        private readonly IUIService _uiService;
        private readonly IMediaController _mediaController;
        
        private UIPlaybackView _uiPlaybackView;

        public UIPlaybackComponentController(
            IUIService uiService,
            IMediaController mediaController)
        {
            _uiService = uiService;
            _mediaController = mediaController;
        }
        
        public void ShowComponent()
        {
            _uiPlaybackView = _uiService.Get<UIPlaybackView>();
            
            _uiPlaybackView.OnPlayButtonClickEvent += PlayClicked;
            _uiPlaybackView.OnPauseButtonClickEvent += PauseClicked;

            _mediaController.VideoLoaded += PauseWithoutNotification;
            _mediaController.VideoEnded += PauseWithoutNotification;
            
            _uiService.Show<UIPlaybackView>();
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
            _uiPlaybackView.SetPauseWithoutNotification();
        }

        public void HideComponent()
        {
            _uiPlaybackView.OnPlayButtonClickEvent -= PlayClicked;
            _uiPlaybackView.OnPauseButtonClickEvent -= PauseClicked;
            
            _mediaController.VideoLoaded -= PauseClicked;
            _mediaController.VideoEnded -= PauseClicked;
            
            _uiService.Hide<UIPlaybackView>();
        }

        
    }
}
