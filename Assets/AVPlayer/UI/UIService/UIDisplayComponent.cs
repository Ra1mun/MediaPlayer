using UnityEngine;

namespace AVPlayer.UI.UIService
{
    public abstract class UIDisplayComponent : MonoBehaviour
    {
        public abstract void Show();

        public abstract void Hide();
    }
}