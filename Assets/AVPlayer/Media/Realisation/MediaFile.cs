using System;
using RenderHeads.Media.AVProVideo;
using UnityEngine;

namespace AVPlayer.Media
{
    [Serializable]
    public class MediaFile
    {
        [SerializeField] private Sprite _preview;
        [SerializeField] private MediaReference _media;
        [SerializeField] private string _name;

        public Sprite Preview => _preview;
        public MediaReference Media => _media;
        public string Name => _name;
    }
}