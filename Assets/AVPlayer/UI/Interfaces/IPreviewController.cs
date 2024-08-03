using System.Collections;
using System.Collections.Generic;
using AVPlayer.UI.Preview;

namespace AVPlayer.UI.Interfaces
{
    public interface IPreviewController
    {
        public IEnumerable<PreviewView> GetAllPreviews();
        public IEnumerable<PreviewView> GetPreviewsByCount(int count);
    }
}