using System;
using System.Collections.Generic;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService.Interfaces;
using UnityEngine;
using Zenject;

namespace AVPlayer.UI.UIService
{
    public class UIService : IUIService
    {
        private readonly Dictionary<Type, UIDisplayComponent> _viewStorage = new Dictionary<Type, UIDisplayComponent>();
        private readonly Dictionary<Type, GameObject> _initViews = new Dictionary<Type, GameObject>();

        private readonly IInstantiator _instantiator;
        private readonly IUIRoot _uiRoot;

        public UIService(
            IInstantiator instantiator,
            IUIRoot uiRoot)
        {
            _instantiator = instantiator;
            _uiRoot = uiRoot;
        }

        public void LoadComponents()
        {
            var components = Resources.LoadAll<UIDisplayComponent>("UIDisplayComponents");
            foreach (var component in components)
            {
                _viewStorage.Add(component.GetType(), component);
            }

            InitComponents();
        }

        public void Show<T>() where T : UIDisplayComponent
        {
            var t = typeof(T);
            if (!_initViews.ContainsKey(t))
            {
                return;
            }

            var view = _initViews[t];
            var viewComponent = view.GetComponent<T>();
            
            view.transform.SetParent(_uiRoot.Container);
            view.transform.localPosition = Vector3.zero;
            view.transform.localRotation = Quaternion.identity;
            view.transform.localScale = Vector3.one;
            
            viewComponent.Show();
        }
        
        public void Hide<T>() where T : UIDisplayComponent
        {
            var t = typeof(T);
            if (!_initViews.ContainsKey(t))
            {
                return;
            }

            var view = _initViews[t];
            var viewComponent = view.GetComponent<T>();
            
            view.transform.SetParent(_uiRoot.PoolContainer);
            
            viewComponent.Hide();
        }

        public T Get<T>() where T : UIDisplayComponent
        {
            if (_initViews.ContainsKey(typeof(T)))
            {
                var t = typeof(T);
                var view = _initViews[t];

                return view.GetComponent<T>();
            }

            return null;
        }
        
        private void InitComponents()
        {
            foreach (var displayComponent in _viewStorage)
            {
                Init(displayComponent.Key, _uiRoot.PoolContainer);
            }
        }
        
        private void Init(Type t, Transform parent = null)
        {
            if (!_initViews.ContainsKey(t) && _viewStorage.ContainsKey(t))
            {
                GameObject view;
                if (parent == null)
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t]);
                }
                else
                {
                    view = _instantiator.InstantiatePrefab(_viewStorage[t], parent);
                }
                
                _initViews.Add(t, view);
            }
        }
    }
}