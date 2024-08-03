using AVPlayer.UI.Installer;
using UnityEngine;
using Zenject;

namespace AVPlayer.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        [SerializeField] private CameraView _cameraView;
        
        public override void InstallBindings()
        {
            MediaInstaller.Install(Container);
            
            UIServiceInstaller.Install(Container);

            Container
                .Bind<CameraView>()
                .FromInstance(_cameraView)
                .AsSingle();
            
            Container
                .Bind<ApplicationStartup>()
                .AsSingle();
        }
    }
}