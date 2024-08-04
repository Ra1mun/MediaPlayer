using UnityEngine;
using UnityEngine.UI;
using AVPlayer.UI.UIService;
using TMPro;

namespace AVPlayer.UI.Realisation.Playlist
{
    public class UIPlaylistView : UIDisplayComponent
    {
        public RectTransform PreviewContainer => _previewContainer;

        
        [SerializeField] private Button _closePlaylist;
        [SerializeField] private Button _openPlaylist;
        [SerializeField] private RectTransform _previewContainer;
        [SerializeField] private RectTransform _playlistContainer;

        public override void Show()
        {
            _openPlaylist.onClick.AddListener(OpenPlaylist);
            _closePlaylist.onClick.AddListener(ClosePlaylist);
        }

        public void ClosePlaylist()
        {
            _playlistContainer.gameObject.SetActive(false);
        }
        
        public override void Hide()
        {
            _openPlaylist.onClick.RemoveListener(OpenPlaylist);
            _closePlaylist.onClick.RemoveListener(ClosePlaylist);
        }
        
        private void OpenPlaylist()
        {
            _playlistContainer.gameObject.SetActive(true);
        }
    }
}