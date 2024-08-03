using System;
using AVPlayer.UI.UIService;
using UnityEngine;
using UnityEngine.UI;

namespace AVPlayer.UI.Playlist
{
    public class PlaylistView : UIDisplayComponent
    {
        [SerializeField] private Button _closePlaylist;
        [SerializeField] private Button _openPlaylist;
        [SerializeField] private RectTransform _previewContainer;
        [SerializeField] private RectTransform _playlistContainer;
        
        public RectTransform PreviewContainer => _previewContainer;
        
        public override void Show()
        {
            _openPlaylist.onClick.AddListener(OpenPlaylist);
            _closePlaylist.onClick.AddListener(ClosePlaylist);
        }
        
        private void OpenPlaylist()
        {
            _playlistContainer.gameObject.SetActive(true);
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
    }
}