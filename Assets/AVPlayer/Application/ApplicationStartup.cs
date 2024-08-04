using RenderHeads.Media.AVProVideo;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService.Interfaces;
using AVPlayer.Camera;
using UnityEngine;

namespace AVPlayer.Application
{
    public class ApplicationStartup
    {
        private readonly Vector3 _offsetDistanceCamera = new Vector3(0f,0f,-950f);

        private readonly CameraView _cameraView;
        private readonly IUIRoot _uiRoot;
        private readonly MediaPlayer _mediaPlayer;
        private readonly UIDisplayComponentsController _displayComponentsController;

        public ApplicationStartup(
            CameraView cameraView,
            IUIRoot uiRoot,
            MediaPlayer mediaPlayer,
            UIDisplayComponentsController displayComponentsController)
        {
            _cameraView = cameraView;
            _uiRoot = uiRoot;
            _mediaPlayer = mediaPlayer;
            _displayComponentsController = displayComponentsController;

            SetupDisplay();
        }

        private void SetupDisplay()
        {
            _uiRoot.Canvas.worldCamera = _cameraView.Camera;
            _uiRoot.Display.CurrentPlayer = _mediaPlayer;

            _cameraView.transform.position = _offsetDistanceCamera;

            _displayComponentsController.ShowComponents();
        }
    }
}