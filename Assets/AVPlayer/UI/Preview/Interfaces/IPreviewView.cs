using System;
using UnityEngine;
using UnityEngine.UI;

namespace AVPlayer.UI.Preview.Interfaces
{
    public interface IPreviewView
    {
        public Action<string> OnSelectButtonClickEvent { get; set; }
        
        public RectTransform Origin { get; }
        public Image PreviewImage { get; }
        public string PreviewText { set; }
    }
}