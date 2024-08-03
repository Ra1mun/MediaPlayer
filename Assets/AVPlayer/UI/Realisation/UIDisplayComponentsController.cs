using System.Collections.Generic;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Playback;
using AVPlayer.UI.Playlist;
using AVPlayer.UI.UIService;

namespace AVPlayer.UI.Realisation
{
    public class UIDisplayComponentsController
    {
        private readonly List<IDisplayController> _controllers = new List<IDisplayController>();
        
        public UIDisplayComponentsController(
            PlaylistController playlistController,
            PlaybackController playbackController)
        {
            Setup(playlistController);
            Setup(playbackController);
            
        }

        private void Setup(IDisplayController displayController)
        {
            if (displayController == null)
            {
                return;
            }
            
            _controllers.Add(displayController);
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