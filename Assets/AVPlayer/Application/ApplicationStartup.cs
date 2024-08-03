using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using Zenject;

namespace AVPlayer.Application
{
    public class ApplicationStartup
    {
        private readonly MediaPlayer _mediaPlayer;
        private readonly UIRoot _uiRoot;
        private readonly IDisplayRoot _displayRoot;
        private readonly CameraView _cameraView;
        private readonly UIService _uiService;
        private readonly UIDisplayComponentsController _uiDisplayComponentsController;

        public ApplicationStartup(
            MediaPlayer mediaPlayer,
            UIRoot uiRoot,
            IDisplayRoot displayRoot,
            CameraView cameraView,
            UIService uiService,
            UIDisplayComponentsController uiDisplayComponentsController)
        {
            _mediaPlayer = mediaPlayer;
            _uiRoot = uiRoot;
            _displayRoot = displayRoot;
            _cameraView = cameraView;
            _uiService = uiService;
            _uiDisplayComponentsController = uiDisplayComponentsController;

            SetupDisplay();
        }

        private void SetupDisplay()
        {
            _displayRoot.Display.Player = _mediaPlayer;
            _uiRoot.Canvas.worldCamera = _cameraView.Camera;
            
            _uiService.LoadComponents();

            _uiDisplayComponentsController.ShowComponents();
        }
    }
}