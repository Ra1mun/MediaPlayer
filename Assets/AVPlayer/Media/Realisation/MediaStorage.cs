using System;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using AVPlayer.Media.Interfaces;
using AVPlayer.UI.Preview.Realisation;

namespace AVPlayer.Media.Realisation
{
    [CreateAssetMenu(order = 0, fileName = nameof(MediaStorage), menuName = "Media/MediaStorage")]

    public class MediaStorage : ScriptableObject, IMediaStorage
    {
        public UIPreviewView UIPreviewPrefab => _uiPreviewPrefab;
        
        private readonly Dictionary<string, MediaReference> _mediaStorage = new Dictionary<string, MediaReference>();
        private readonly Dictionary<string, Sprite> _previewStorage = new Dictionary<string, Sprite>();

        [SerializeField] private MediaFile[] _mediaFiles;
        [SerializeField] private UIPreviewView _uiPreviewPrefab;
    
        [NonSerialized] private bool _isInit;
    
        public MediaReference GetVideo(string videoName)
        {
            if (!_isInit)
            {
                Init();
            }

            return _mediaStorage[videoName];
        }
    
        public Sprite GetPreview(string videoName)
        {
            if (!_isInit)
            {
                Init();
            }

            return _previewStorage[videoName];
        }

        public IEnumerable<string> GetNames()
        {
            if (!_isInit)
            {
                Init();
            }

            return _mediaStorage.Keys;
        }
        
        private void Init()
        {
            for (int i = 0; i < _mediaFiles.Length; i++)
            {
                if (!_mediaStorage.ContainsKey(_mediaFiles[i].Name))
                {
                    _mediaStorage.Add(_mediaFiles[i].Name, _mediaFiles[i].Media);
                }

                if (!_previewStorage.ContainsKey(_mediaFiles[i].Name))
                {
                    _previewStorage.Add(_mediaFiles[i].Name, _mediaFiles[i].Preview);
                }
            }

            _isInit = true;
        }
    }
}


