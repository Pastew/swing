using System;
using System.Collections.Generic;
using Components.UIStars;
using DG.Tweening;
using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace MetaGame
{
    public class LevelResultPanel : UIPanel
    {
        [Header("Text")] [SerializeField] private List<String> _textPerStar;
        [SerializeField] private Text _resultText;
        [SerializeField] private AnimationCurve _textScaleInAnimCurve;
        [SerializeField] private float _duration = 1;

        [Header("Stars")] [SerializeField] private GameObject _starCollectedUIPrefab;
        [SerializeField] private GameObject _starEmptyUIPrefab;
        [SerializeField] private List<GameObject> _starsAnchors;

        [Header("Stats")] [SerializeField] private CanvasGroup _time;
        [SerializeField] private CanvasGroup _touches;
        [SerializeField] private AnimationCurve _textShowupScaleAnimCurve;

        [Header("Buttons")] [SerializeField] private GameObject _buttons;
        
        private LevelScore _levelScore;
        private List<StarUI> _intantiatedStars;

        public override void Awake()
        {
            base.Awake();
            _intantiatedStars = new List<StarUI>();
            
            if (_starsAnchors.Count != 3)
                throw new ArgumentException("There should be 3 star anchors provided in editor!");
        }

        public void Setup(LevelScore levelScore)
        {
            _levelScore = levelScore;
            _time.GetComponentInChildren<Text>().text = String.Format("{0:0.00}s", levelScore.Seconds);
            _touches.GetComponentInChildren<Text>().text = $"x{levelScore.Clicks}";
            _resultText.text = _textPerStar[levelScore.Stars];

            _intantiatedStars.ForEach(star => star.KillAndDestroy());
            _intantiatedStars.Clear();
            _time.alpha = 0;
            _touches.alpha = 0;
            _resultText.transform.localScale = Vector3.zero;
            _buttons.transform.Translate(Vector3.down * 400);
        }
        
        public override void Show()
        {
            base.Show();
            
            ShowStars(_levelScore.Stars);
            Sequence s = DOTween.Sequence();

            s.Append(_resultText.DOFade(1, _duration));
            s.Join(_resultText.transform.DOScale(1, _duration).SetEase(_textScaleInAnimCurve));
            
            s.Append(_time.DOFade(1, _duration).SetEase(Ease.InExpo));
            s.Join(_time.transform.DOScale(2, 1).SetEase(_textShowupScaleAnimCurve));

            s.Join(_touches.DOFade(1, _duration).SetEase(Ease.InExpo));
            s.Join(_touches.transform.DOScale(2, _duration).SetEase(_textShowupScaleAnimCurve));
            
            s.Append(_buttons.GetComponent<RectTransform>().DOAnchorPos(Vector3.zero, _duration).SetEase(Ease.OutExpo));
            s.AppendCallback(() => { MetaEvents.LevelResultShownEvent(); });
            s.Play();
        }

        private void ShowStars(int stars)
        {
            for (int i = 0; i < 3; ++i)
            {
                GameObject prefabToInstantiate = i < stars
                    ? _starCollectedUIPrefab
                    : _starEmptyUIPrefab;

                _intantiatedStars.Add(Instantiate(prefabToInstantiate, _starsAnchors[i].transform).GetComponent<StarUI>());
            }
        }
    }
}