using UnityEngine;
using Zenject;
using AVPlayer.UI.Preview.Interfaces;

namespace AVPlayer.UI.Preview.Realisation
{
    public class PreviewFactory
    {
        private readonly IInstantiator _instantiator;

        public PreviewFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IPreviewView Create(UIPreviewView prefab, string previewName, Sprite previewImage)
        {
            var obj = _instantiator.InstantiatePrefab(prefab);
            
            var viewComponent = obj.GetComponent<IPreviewView>();
            viewComponent.PreviewImage.sprite = previewImage;
            viewComponent.PreviewText = previewName;

            return viewComponent;
        }
        
        public IPreviewView Create(UIPreviewView prefab, string previewName, Sprite previewImage, Transform parent)
        {
            var obj = _instantiator.InstantiatePrefab(prefab, parent);
            
            var viewComponent = obj.GetComponent<IPreviewView>();
            viewComponent.PreviewImage.sprite = previewImage;
            viewComponent.PreviewText = previewName;
            
            return viewComponent;
        }
    }
}