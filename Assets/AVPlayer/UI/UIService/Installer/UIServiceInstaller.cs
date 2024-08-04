using Zenject;
using AVPlayer.UI.Preview.Interfaces;
using AVPlayer.UI.Preview.Realisation;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.Realisation.Playback;
using AVPlayer.UI.Realisation.Playlist;
using AVPlayer.UI.UIService.Interfaces;

namespace AVPlayer.UI.UIService.Installer
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
                .To<UI.UIService.UIService>()
                .AsSingle();
            
            Container
                .Bind<IPreviewController>()
                .To<PreviewBuilder>()
                .AsSingle();

            Container
                .Bind<UIPlaybackComponentController>()
                .AsSingle();

            Container
                .Bind<UIPlaylistComponentController>()
                .AsSingle();

            Container
                .Bind<UIDisplayComponentsController>()
                .AsSingle();
        }
    }
}