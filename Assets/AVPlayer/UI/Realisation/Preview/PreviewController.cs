using System.Collections.Generic;
using System.Linq;
using AVPlayer.Media;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Playlist;
using UnityEngine;
using Zenject;

namespace AVPlayer.UI.Preview
{
    public class PreviewController : IPreviewController
    {
        private readonly List<PreviewView> _initPreviews = new List<PreviewView>();
        
        private readonly MediaStorage _mediaStorage;
        private readonly PreviewView _prefab;
        private readonly IInstantiator _instantiator;
        private readonly IUIRoot _uiRoot;
        private readonly PlaylistController _playlist;

        public PreviewController(
            MediaStorage mediaStorage,
            PreviewView prefab,
            IInstantiator instantiator,
            IUIRoot uiRoot)
        {
            _mediaStorage = mediaStorage;
            _prefab = prefab;
            _instantiator = instantiator;
            _uiRoot = uiRoot;

            InitPreviews();
        }
        
        public IEnumerable<PreviewView> GetAllPreviews()
        {
            return _initPreviews;
        }

        public IEnumerable<PreviewView> GetPreviewsByCount(int count)
        {
            return _initPreviews
                .Take(count);
        }

        private void InitPreviews()
        {
            foreach (var mediaName in _mediaStorage.GetNames())
            {
                Init(mediaName, _uiRoot.PoolContainer);
            }
        }

        private void Init(string videoName, Transform parent = null)
        {
            GameObject obj;
            if (parent == null)
            {
                obj = _instantiator.InstantiatePrefab(_prefab);
            }
            else
            {
                obj = _instantiator.InstantiatePrefab(_prefab, parent);
            }

            var viewComponent = obj.GetComponent<PreviewView>();
            viewComponent.PreviewImage.sprite = _mediaStorage.GetPreview(videoName);
            viewComponent.PreviewText = videoName;

            _initPreviews.Add(viewComponent);
        }
    }
}