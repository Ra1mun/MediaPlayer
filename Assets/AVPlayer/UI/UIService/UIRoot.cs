using AVPlayer.UI.Display;
using AVPlayer.UI.Interfaces;
using UnityEngine;

namespace AVPlayer.UI.UIService
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _container;
        [SerializeField] private RectTransform _poolContainer;
        [SerializeField] private DisplayRoot _displayRoot;
        
        public RectTransform Container => _container;
        public RectTransform PoolContainer => _poolContainer;
        public Canvas Canvas => _canvas;
        public DisplayRoot DisplayRoot => _displayRoot;
    }
}