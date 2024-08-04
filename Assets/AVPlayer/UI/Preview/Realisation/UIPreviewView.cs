using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using AVPlayer.UI.Preview.Interfaces;

namespace AVPlayer.UI.Preview.Realisation
{
    public class UIPreviewView : MonoBehaviour, IPreviewView
    {
        public Action<string> OnSelectButtonClickEvent { get; set; }

        public RectTransform Origin => _origin;
        public Image PreviewImage => _selectButton.image;

        public string PreviewText
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Debug.LogError(nameof(value));
                }

                _previewText.text = value;
            }
        }
        
        [SerializeField] private RectTransform _origin;
        [SerializeField] private Button _selectButton;
        [SerializeField] private TMP_Text _previewText;
        
        private void OnEnable()
        {
            _selectButton.onClick.AddListener(OnSelectButtonClick);
        }
        
        private void OnSelectButtonClick()
        {
            OnSelectButtonClickEvent?.Invoke(_previewText.text);
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(OnSelectButtonClick);
        }
    }
}