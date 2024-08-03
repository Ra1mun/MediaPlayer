using AVPlayer.Media;
using AVPlayer.UI.Installer;
using UnityEngine;
using Zenject;

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