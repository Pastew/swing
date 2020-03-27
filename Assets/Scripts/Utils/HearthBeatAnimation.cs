using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public class HearthBeatAnimation : MonoBehaviour
    {
        [SerializeField] private float _firstDelay = 2f;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private AnimationCurve _animCurve;

        private Tween tween;

        void Start()
        {
            Animate(_firstDelay);
        }

        private void Animate(float delay = 0)
        {
            tween = transform.DOScale(transform.localScale * 2, _duration)
                .SetEase(_animCurve)
                .SetDelay(delay)
                .OnComplete(() => Animate());
        }

        public void KillAnimation()
        {
            tween?.Kill();
            Destroy(this);
        }
    }
}