using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Components.UIStars
{
    public class EmptyStarUI : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _imageFadeInDuration = 2f;
        [SerializeField] private AnimationCurve _imageFadeInAnimCurve;

        private void OnEnable()
        {
            _image.color = new Color(1, 1, 1, 0);
            _image.DOFade(1, _imageFadeInDuration).SetEase(_imageFadeInAnimCurve);
        }
    }
}
