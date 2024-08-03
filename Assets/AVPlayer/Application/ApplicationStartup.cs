using System;
using AVPlayer.UI.Interfaces;
using AVPlayer.UI.Playback;
using AVPlayer.UI.Playlist;
using AVPlayer.UI.Preview;
using AVPlayer.UI.Realisation;
using AVPlayer.UI.UIService;
using AVPlayer.UI.UIService.Interfaces;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using Zenject;

namespace AVPlayer.Application
{
    public class ApplicationStartup
    {
        private readonly CameraView _cameraView;
        private readonly IUIRoot _uiRoot;
        private readonly MediaPlayer _mediaPlayer;
        private readonly UIDisplayComponentsController _displayController;

        public ApplicationStartup(
            CameraView cameraView,
            IUIRoot uiRoot,
            MediaPlayer mediaPlayer,
            UIDisplayComponentsController displayController)
        {
            _cameraView = cameraView;
            _uiRoot = uiRoot;
            _mediaPlayer = mediaPlayer;
            _displayController = displayController;

            SetupDisplay();
        }

        private void SetupDisplay()
        {
            _uiRoot.Canvas.worldCamera = _cameraView.Camera;
            _uiRoot.DisplayRoot.Display.Player = _mediaPlayer;
            
            _displayController.ShowComponents();
        }
    }
}