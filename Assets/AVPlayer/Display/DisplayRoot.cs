using RenderHeads.Media.AVProVideo;
using TMPro;
using UnityEngine;

namespace AVPlayer.Display
{
    public class DisplayRoot : MonoBehaviour
    {
        public string MediaHeaderText
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Debug.LogError("Media data failed");
                    return;
                }

                _currentMediaHeader.text = value;
            }
        }

        public MediaPlayer CurrentPlayer
        {
            set => _display.Player = value;
        }
        
        [SerializeField] private DisplayUGUI _display;
        [SerializeField] private TMP_Text _currentMediaHeader;

    }
}
