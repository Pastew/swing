using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Components.UIStars
{
    public class StarUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _imageFadeInDuration = 2f;
        [SerializeField] private AnimationCurve _imageFadeInAnimCurve;
        
        private TweenerCore<Color, Color, ColorOptions> _tween;

        private void Start()
        {
            _image.color = new Color(1, 1, 1, 0);
            _tween = _image.DOFade(1, _imageFadeInDuration).SetEase(_imageFadeInAnimCurve);
        }

        public void KillAndDestroy()
        {
            if(_tween != null && _tween.IsActive())
                _tween.Kill();
            
            _tween = null;
            Destroy(gameObject);
        }
    }
}
