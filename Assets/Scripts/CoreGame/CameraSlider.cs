using DG.Tweening;
using UnityEngine;

namespace CoreGame
{
    public class CameraSlider : MonoBehaviour
    {
        [SerializeField] private float _slideOutSize = 1000;
        [SerializeField] private Ease _ease = Ease.OutBounce;
        [SerializeField] private float _duration = 0.5f;

        private Camera _camera;
        private float _startingCameraSize;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _startingCameraSize = _camera.orthographicSize;
        }

        public Tweener SlideIn()
        {
            return Slide(_startingCameraSize);
        }

        public Tweener SlideOut()
        {
            return Slide(_slideOutSize);
        }

        private Tweener Slide(float size)
        {
            return _camera.DOOrthoSize(size, _duration).SetEase(_ease);
        }

        public void SlideOutInstant()
        {
            _camera.orthographicSize = _slideOutSize;
        }
    }
}