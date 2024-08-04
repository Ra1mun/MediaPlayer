using AVPlayer.Display;
using RenderHeads.Media.AVProVideo;
using UnityEngine;

namespace AVPlayer.UI.UIService.Interfaces
{
    public interface IUIRoot
    {
        public RectTransform Container { get; }
        public RectTransform PoolContainer { get; }
        public Canvas Canvas { get; }
        public DisplayRoot Display { get; }
    }
}