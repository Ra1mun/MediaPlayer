using UnityEngine;

namespace AVPlayer.Camera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public UnityEngine.Camera Camera => _camera;
    }
}
