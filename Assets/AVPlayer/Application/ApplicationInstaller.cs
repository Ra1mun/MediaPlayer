using Zenject;
using AVPlayer.Camera;
using AVPlayer.Media.Installer;
using AVPlayer.UI.UIService.Installer;

namespace AVPlayer.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CameraView>()
                .FromComponentInNewPrefabResource(nameof(CameraView))
                .AsSingle();
            
            MediaInstaller.Install(Container);
            
            UIServiceInstaller.Install(Container);

            Container
                .Bind<ApplicationStartup>()
                .AsSingle()
                .NonLazy();
        }
    }
}