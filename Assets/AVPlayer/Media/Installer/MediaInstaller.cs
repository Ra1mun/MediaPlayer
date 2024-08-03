using AVPlayer.Media;
using RenderHeads.Media.AVProVideo;
using Zenject;

public class MediaInstaller : Installer<MediaInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<MediaStorage>()
            .FromScriptableObjectResource(nameof(MediaStorage))
            .AsSingle();
        
        Container
            .Bind<MediaPlayer>()
            .FromComponentInNewPrefabResource(nameof(MediaPlayer))
            .AsSingle();

        Container
            .Bind<MediaController>()
            .AsSingle();
    }
}