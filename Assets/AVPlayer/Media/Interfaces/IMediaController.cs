using System;

namespace AVPlayer.Media.Interfaces
{
    public interface IMediaController
    {
        public Action VideoLoaded { get; set; }
        public Action VideoEnded { get; set; }
        
        public bool TryToLoadVideo(string mediaName, bool autoPlay = false);
        
        public void PlayVideo();
        public void StopVideo();
    }
}