using TMPro;
using UnityEngine.UI;

namespace AVPlayer.UI.Interfaces
{
    public interface IPreviewView
    {
        public Image PreviewImage { get; set; }
        public string PreviewText { get; set; }
    }
}