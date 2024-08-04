using System.Collections.Generic;

namespace AVPlayer.UI.Preview.Interfaces
{
    public interface IPreviewController
    {
        public IEnumerable<IPreviewView> GetAllPreviews();
        public IEnumerable<IPreviewView> GetPreviewsByCount(int count);
    }
}