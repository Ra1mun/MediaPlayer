using AVPlayer.UI.Display;
using UnityEngine;

namespace AVPlayer.UI.Interfaces
{
    public interface IUIRoot
    {
        public RectTransform Container { get; }
        public RectTransform PoolContainer { get; }
        public Canvas Canvas { get; }
        public DisplayRoot DisplayRoot { get; }
    }
}