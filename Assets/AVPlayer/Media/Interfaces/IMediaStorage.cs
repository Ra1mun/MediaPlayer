using System.Collections.Generic;
using AVPlayer.UI.Preview.Realisation;
using RenderHeads.Media.AVProVideo;
using UnityEngine;

namespace AVPlayer.Media.Interfaces
{
    public interface IMediaStorage
    {
        public UIPreviewView UIPreviewPrefab { get; }
        
        public MediaReference GetVideo(string videoName);
        public Sprite GetPreview(string videoName);
        public IEnumerable<string> GetNames();
    }
}