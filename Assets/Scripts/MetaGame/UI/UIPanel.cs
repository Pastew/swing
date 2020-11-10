using DG.Tweening;
using UnityEngine;

namespace MetaGame
{
    public abstract class UIPanel : MonoBehaviour
    {
        private GameObject _anchor;

        private CanvasGroup _canvasGroup;

        private float _fadeDuration = 0.15f;

        public virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _anchor = transform.GetChild(0).gameObject;
            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        private void Start()
        {
            Hide(true);
        }

        public virtual Tween Show()
        {
            Sequence s = DOTween.Sequence();
            s.AppendCallback(() => _anchor.SetActive(true));
            s.Append(_canvasGroup
                .DOFade(1, _fadeDuration)
                .SetEase(Ease.InExpo)
                .OnComplete(() => _canvasGroup.interactable = true));
            
            s.Play();
            return s;
        }

        public virtual Tween Hide(bool instant = false)
        {
            _canvasGroup.interactable = false;

            Tween tween = null;

            if (instant)
            {
                _canvasGroup.alpha = 0;
                _anchor.SetActive(false);
            }
            else
            {
                tween = _canvasGroup
                    .DOFade(0, _fadeDuration)
                    .SetEase(Ease.OutExpo)
                    .OnComplete(() => _anchor.SetActive(false));
            }

            return tween;
        }
    }
}