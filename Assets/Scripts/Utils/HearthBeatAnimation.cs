using System;
using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public class HearthBeatAnimation : MonoBehaviour
    {
        [SerializeField] private float _firstDelay = 3f;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private AnimationCurve _animCurve;
        private Vector3 _startScale;

        private Tween tween;

        private void Awake()
        {
            _startScale = transform.localScale;
        }

        private void Animate(float delay = 0)
        {
            tween = transform.DOScale(_startScale * 2, _duration)
                .SetEase(_animCurve)
                .SetDelay(delay)
                .SetLoops(-1);
        }

        public void KillAnimation()
        {
            tween?.Complete();
        }

        private void OnDisable()
        {
            tween?.Kill();
            transform.localScale = _startScale;
        }

        private void OnEnable()
        {
            Animate(_firstDelay);
        }
    }
}