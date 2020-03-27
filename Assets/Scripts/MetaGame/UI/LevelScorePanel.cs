using System;
using System.Collections.Generic;
using DG.Tweening;
using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace MetaGame.UI
{
    public class LevelScorePanel : MonoBehaviour, UIPanel
    {
        [Header("Text")] [SerializeField] private List<String> _textPerStar;
        [SerializeField] private Text _resultText;
        [SerializeField] private AnimationCurve _textScaleInAnimCurve;
        [SerializeField] private float _textScaleInDuration = 2.1f;
        [SerializeField] private float _fadeOutDuration = 0.3f;

        [Header("Stars")] [SerializeField] private GameObject _starCollectedUIPrefab;
        [SerializeField] private GameObject _starEmptyUIPrefab;
        [SerializeField] private List<GameObject> _starsAnchors;
        [SerializeField] private float _delayBetweenStars = 0.3f;

        [Header("Stats")] [SerializeField] private CanvasGroup _time;
        [SerializeField] private CanvasGroup _touches;
        [SerializeField] private AnimationCurve _textShowupScaleAnimCurve;

        [Header("Buttons")] [SerializeField] private GameObject _buttons;

        private void Awake()
        {
            _resultText.transform.localScale = Vector3.zero;
            if (_starsAnchors.Count != 3)
                throw new ArgumentException("There should be 3 star anchors provided in editor!");

            _buttons.transform.Translate(Vector3.right * 800);

            _time.alpha = 0;
            _touches.alpha = 0;

            SetButtonsInteractable(false);
        }

        public void Show(LevelScore levelScore)
        {            
            int stars = levelScore._stars;
            _time.GetComponentInChildren<Text>().text = String.Format("{0:0.00}s", levelScore._seconds);
            _touches.GetComponentInChildren<Text>().text = $"x{levelScore._clicks}";
            _resultText.text = _textPerStar[stars];
            
            ShowStars(stars);
            Sequence s = DOTween.Sequence();

            print(levelScore._seconds);
            s.Append(_time.DOFade(1, 1f).SetEase(Ease.InExpo));
            s.Join(_time.transform.DOScale(2, 1).SetDelay(0.3f).SetEase(_textShowupScaleAnimCurve));

            s.Join(_touches.DOFade(1, 1f).SetEase(Ease.InExpo));
            s.Join(_touches.transform.DOScale(2, 1).SetEase(_textShowupScaleAnimCurve));

            s.Join(_resultText.DOFade(1, _textScaleInDuration / 2f));
            s.Join(_resultText.transform.DOScale(1, _textScaleInDuration).SetEase(_textScaleInAnimCurve));
            s.Append(_buttons.GetComponent<RectTransform>().DOAnchorPos(Vector3.zero, 1f).SetEase(Ease.OutExpo));
            s.AppendCallback(() => SetButtonsInteractable(true));
            s.AppendCallback(() => { MetaEvents.LevelResultShown(); });
            s.Play();
        }

        public void Hide()
        {
            GetComponent<CanvasGroup>()
                .DOFade(0, _fadeOutDuration)
                .OnComplete(() => Destroy(gameObject));
        }

        private void ShowStars(int stars)
        {
            for (int i = 0; i < 3; ++i)
            {
                GameObject prefabToInstantiate = i < stars
                    ? _starCollectedUIPrefab
                    : _starEmptyUIPrefab;

                Instantiate(prefabToInstantiate, _starsAnchors[i].transform);
            }
        }

        private void SetButtonsInteractable(bool interactable)
        {
            foreach (Transform buttonTransform in _buttons.transform)
                buttonTransform.GetComponent<Button>().interactable = interactable;
        }
    }
}