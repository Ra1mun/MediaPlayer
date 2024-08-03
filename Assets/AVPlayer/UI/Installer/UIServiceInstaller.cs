using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Playback;
using AVPlayer.UI.Playlist;
using AVPlayer.UI.Preview;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService;
using AVPlayer.UI.UIService.Interfaces;
using Zenject;

namespace AVPlayer.UI.Installer
{
    public class UIServiceInstaller : Installer<UIServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUIRoot>()
                .To<UIRoot>()
                .FromComponentInNewPrefabResource(nameof(UIRoot))
                .AsSingle();
            
            Container
                .Bind<IUIService>()
                .To<UIService.UIService>()
                .AsSingle();

            Container
                .Bind<PlaybackController>()
                .AsSingle();
            
            Container
                .Bind<PreviewView>()
                .FromComponentInNewPrefabResource(nameof(PreviewView))
                .AsSingle();
            
            Container
                .Bind<IPreviewController>()
                .To<PreviewController>()
                .AsSingle();

            Container
                .Bind<PlaylistController>()
                .AsSingle();
            
            Container
                .Bind<UIDisplayComponentsController>()
                .AsSingle();
        }
    }
}