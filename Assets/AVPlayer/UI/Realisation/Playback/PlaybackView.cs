using System;
using AVPlayer.UI.UIService;
using UnityEngine;
using UnityEngine.UI;

namespace AVPlayer.UI.Playback
{
    public class PlaybackView : UIDisplayComponent
    {
        public Action OnPlayButtonClickEvent;
        public Action OnPauseButtonClickEvent;
    
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _pauseButton;

        public override void Show()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }
        
        public void SetPauseWithoutNotification()
        {
            _playButton.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
        }

        private void OnPlayButtonClick()
        {
            OnPlayButtonClickEvent?.Invoke();
        
            _playButton.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
        }
    
        private void OnPauseButtonClick()
        {
            OnPauseButtonClickEvent?.Invoke();
        
            _playButton.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
        }
        
        public override void Hide()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }
    }
}
