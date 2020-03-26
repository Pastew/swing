using System;
using System.Collections.Generic;
using Components.UIStars;
using DG.Tweening;
using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace MetaGame.UI
{
    public class LevelScorePanel : MonoBehaviour, UIPanel
    {
        [Header("Text")] [SerializeField] private List<String> _textPerStar;
        [SerializeField] private Text _text;
        [SerializeField] private AnimationCurve _textScaleInAnimCurve;
        [SerializeField] private float _textScaleInDuration = 2.1f;
        [SerializeField] private float _fadeOutDuration = 0.3f;

        private StarsResult _starsResult;

        private void Awake()
        {
            _starsResult = GetComponentInChildren<StarsResult>();
            _text.transform.localScale = Vector3.zero;
        }

        public Tween Show(LevelScore levelScore)
        {
            int stars = levelScore._stars;

            _starsResult.ShowStars(stars);

            _text.text = _textPerStar[stars];
            _text.DOFade(1, _textScaleInDuration / 2f);
            _text.transform.localScale = Vector3.zero;
            return _text.transform.DOScale(1, _textScaleInDuration).SetEase(_textScaleInAnimCurve);
        }

        public void Hide()
        {
            transform.DOScale(0, 0.4f).SetEase(Ease.InExpo).OnComplete(() =>Destroy(gameObject));
            _text.DOFade(0, _fadeOutDuration);
        }
    }
}