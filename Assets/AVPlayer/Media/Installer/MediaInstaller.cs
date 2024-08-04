using RenderHeads.Media.AVProVideo;
using Zenject;
using AVPlayer.Media.Interfaces;
using AVPlayer.Media.Realisation;

namespace AVPlayer.Media.Installer
{
    public class MediaInstaller : Installer<MediaInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MediaPlayer>()
                .FromComponentInNewPrefabResource(nameof(MediaPlayer))
                .AsSingle();
        
            Container
                .Bind<IMediaStorage>()
                .To<MediaStorage>()
                .FromScriptableObjectResource(nameof(MediaStorage))
                .AsSingle();
        
            Container
                .Bind<IMediaController>()
                .To<MediaController>()
                .AsSingle();
        }
    }
}