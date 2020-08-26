using DG.Tweening;
using UnityEngine;

namespace MetaGame
{
    public abstract class UIPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _anchor;

        private CanvasGroup _canvasGroup;

        private float _fadeDuration = 0.3f;

        public virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Show()
        {
            _anchor.SetActive(true);
            _canvasGroup.interactable = true;
            _canvasGroup
                .DOFade(1, _fadeDuration).SetEase(Ease.InExpo);
        }

        public virtual void Hide(bool instant = false)
        {
            _canvasGroup.interactable = false;

            if (instant)
            {
                _canvasGroup.alpha = 0;
                _anchor.SetActive(false);
            }
            else
            {
                _canvasGroup
                    .DOFade(0, _fadeDuration)
                    .SetEase(Ease.OutExpo)
                    .OnComplete(() => _anchor.SetActive(false));
            }
        }
    }
}