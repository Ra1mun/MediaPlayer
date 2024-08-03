using RenderHeads.Media.AVProVideo;
using TMPro;

namespace AVPlayer.UI.Interfaces
{
    public interface IDisplayRoot
    {
        public DisplayUGUI Display { get; }
        public TMP_Text Header { get; }
    }
}