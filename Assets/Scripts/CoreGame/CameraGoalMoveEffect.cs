using DG.Tweening;
using UnityEngine;

namespace CoreGame
{
    public class CameraGoalMoveEffect : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private AnimationCurve _sizeAnimCurve;
        [SerializeField] private AnimationCurve _moveAnimCurve;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        public Tweener MoveToGoal()
        {
            _camera.DOOrthoSize(0.01f, _duration).SetEase(_sizeAnimCurve);
            Vector2 goalPos = FindObjectOfType<Goal>().transform.position;
            Vector3 targetPos = new Vector3{x = goalPos.x, y = goalPos.y, z = transform.position.z};
            return _camera.transform.DOMove(targetPos, _duration).SetEase(_moveAnimCurve);
        }
    }
}