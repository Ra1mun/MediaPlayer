using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using AVPlayer.Media.Interfaces;
using AVPlayer.UI.Preview.Interfaces;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.UI.Preview.Realisation
{
    public class PreviewBuilder : IPreviewController
    {
        private readonly List<IPreviewView> _initPreviews = new List<IPreviewView>();
        
        private readonly IMediaStorage _mediaStorage;
        private readonly IUIRoot _uiRoot;
        private readonly PreviewFactory _factory;

        public PreviewBuilder(
            IMediaStorage mediaStorage,
            IInstantiator instantiator,
            IUIRoot uiRoot)
        {
            _mediaStorage = mediaStorage;
            _uiRoot = uiRoot;
            
            _factory = new PreviewFactory(instantiator);

            InitPreviews();
        }
        
        public IEnumerable<IPreviewView> GetAllPreviews()
        {
            return _initPreviews;
        }

        public IEnumerable<IPreviewView> GetPreviewsByCount(int count)
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
            IPreviewView view;
            if (parent == null)
            {
                view = _factory.Create(
                    _mediaStorage.UIPreviewPrefab,
                    videoName,
                    _mediaStorage.GetPreview(videoName));
            }
            else
            {
                view = _factory.Create(
                    _mediaStorage.UIPreviewPrefab,
                    videoName,
                    _mediaStorage.GetPreview(videoName),
                    parent);
            }

            _initPreviews.Add(view);
        }
    }
}