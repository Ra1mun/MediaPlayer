using AVPlayer.Display;
using UnityEngine;
using AVPlayer.UI.UIService.Interfaces;
using RenderHeads.Media.AVProVideo;

namespace AVPlayer.UI.UIService
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        public RectTransform Container => _container;
        public RectTransform PoolContainer => _poolContainer;
        public Canvas Canvas => _canvas;
        public DisplayRoot Display => _displayRoot;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _poolContainer;
        [SerializeField] private DisplayRoot _displayRoot;
    }
}