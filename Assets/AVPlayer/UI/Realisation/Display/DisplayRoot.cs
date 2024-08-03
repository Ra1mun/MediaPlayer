using AVPlayer.UI.Interfaces;
using RenderHeads.Media.AVProVideo;
using TMPro;
using UnityEngine;

namespace AVPlayer.UI.Display
{
    public class DisplayRoot : MonoBehaviour, IDisplayRoot
    {
        [SerializeField] private DisplayUGUI _display;
        [SerializeField] private TMP_Text _header;

        public DisplayUGUI Display => _display;
        public TMP_Text Header => _header;
    }
}
