using System;
using AVPlayer.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AVPlayer.UI.Preview
{
    public class PreviewView : MonoBehaviour, IPreviewView
    {
        public Action<string> OnSelectButtonClickEvent;
        
        [SerializeField] private Button _selectButton;
        [SerializeField] private TMP_Text _previewText;

        public Image PreviewImage
        {
            get => _selectButton.image;
            set => _selectButton.image = value;
        }

        public string PreviewText
        {
            get => _previewText.text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Debug.LogError(nameof(value));
                }

                _previewText.text = value;
            }
        }

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