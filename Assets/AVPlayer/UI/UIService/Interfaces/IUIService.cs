namespace AVPlayer.UI.UIService.Interfaces
{
    public interface IUIService
    {
        public void LoadComponents();
        public void Show<T>() where T : UIDisplayComponent;
        public void Hide<T>() where T : UIDisplayComponent;
        public T Get<T>() where T : UIDisplayComponent;
    }
}