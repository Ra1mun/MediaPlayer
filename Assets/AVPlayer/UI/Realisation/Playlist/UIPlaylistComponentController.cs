using System.Collections.Generic;
using UnityEngine;
using AVPlayer.Media.Interfaces;
using AVPlayer.UI.Preview.Interfaces;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.UI.Realisation.Playlist
{
    public class UIPlaylistComponentController : IDisplayComponentController
    {
        private readonly List<IPreviewView> _mediaViews = new List<IPreviewView>();

        private readonly IUIService _uiService;
        private readonly IPreviewController _previewController;
        private readonly IMediaController _mediaController;
        
        private UIPlaylistView _uiPlaylistView;


        public UIPlaylistComponentController(
            IUIService uiService,
            IPreviewController previewController,
            IMediaController mediaController)
        {
            _uiService = uiService;
            _previewController = previewController;
            _mediaController = mediaController;
        }
        
        public void ShowComponent()
        {
            _uiPlaylistView = _uiService.Get<UIPlaylistView>();
            
            foreach (var preview in _previewController.GetAllPreviews())
            {
                AddPreview(preview);
            }
            
            _uiService.Show<UIPlaylistView>();
        }

        private void AddPreview(IPreviewView view)
        {
            
            view.OnSelectButtonClickEvent += SelectVideo;
            
            view.Origin.SetParent(_uiPlaylistView.PreviewContainer);
            view.Origin.localPosition = Vector3.zero;
            view.Origin.localRotation = Quaternion.identity;
            view.Origin.localScale = Vector3.one;
            
            _mediaViews.Add(view);
        }

        private void SelectVideo(string mediaName)
        {
            if (!_mediaController.TryToLoadVideo(mediaName))
            {
                return;
            }
            
            _uiPlaylistView.ClosePlaylist();
        }

        public void HideComponent()
        {
            for (int i = 0; i < _mediaViews.Count; i++)
            {
                _mediaViews[i].OnSelectButtonClickEvent -= SelectVideo;
            }
            
            _mediaViews.Clear();
            
            _uiService.Hide<UIPlaylistView>();
        }
    }
}