using System;
using System.Collections.Generic;
using AVPlayer.Media;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Preview;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService;
using UnityEngine;

namespace AVPlayer.UI.Playlist
{
    public class PlaylistController : IDisplayController
    {
        private readonly PlaylistView _playlistView;
        private readonly UIService.UIService _uiService;
        private readonly PreviewController _previewController;
        private readonly MediaController _mediaController;
        private readonly List<PreviewView> _mediaViews = new();

        public PlaylistController(
            UIService.UIService uiService,
            PreviewController previewController,
            MediaController mediaController)
        {
            _uiService = uiService;
            _previewController = previewController;
            _mediaController = mediaController;
            _playlistView = _uiService.Get<PlaylistView>();
        }
        
        public void ShowComponent()
        {
            foreach (var preview in _previewController.GetAllPreviews())
            {
                AddPreview(preview);
            }
            
            _uiService.Show<PlaylistView>();
        }

        private void AddPreview(PreviewView view)
        {
            view.OnSelectButtonClickEvent += SelectVideo;
            
            view.transform.SetParent(_playlistView.PreviewContainer);
            view.transform.localPosition = Vector3.zero;
            view.transform.localRotation = Quaternion.identity;
            view.transform.localScale = Vector3.one;
            
            _mediaViews.Add(view);
        }

        private void SelectVideo(string mediaName)
        {
            if (!_mediaController.TryToLoadVideo(mediaName))
            {
                return;
            }
            
            _playlistView.ClosePlaylist();
        }

        public void HideComponent()
        {
            for (int i = 0; i < _mediaViews.Count; i++)
            {
                _mediaViews[i].OnSelectButtonClickEvent -= SelectVideo;
            }
            
            _mediaViews.Clear();
            
            _uiService.Hide<PlaylistView>();
        }
    }
}