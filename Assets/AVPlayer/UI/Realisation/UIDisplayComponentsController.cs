using System.Collections.Generic;
using AVPlayer.UI.Realisation.Playback;
using AVPlayer.UI.Realisation.Playlist;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.UI.Realisation
{
    public class UIDisplayComponentsController
    {
        private readonly List<IDisplayComponentController> _controllers = new List<IDisplayComponentController>();
        
        public UIDisplayComponentsController(
            UIPlaylistComponentController uiPlaylistComponentController,
            UIPlaybackComponentController uiPlaybackComponentController)
        {
            Setup(uiPlaylistComponentController);
            Setup(uiPlaybackComponentController);
            
        }

        private void Setup(IDisplayComponentController displayComponentController)
        {
            if (displayComponentController == null)
            {
                return;
            }
            
            _controllers.Add(displayComponentController);
        }

        public void ShowComponents()
        {
            foreach (var controller in _controllers)
            {
                controller.ShowComponent();
            }
        }
    }
}