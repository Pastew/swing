using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MetaGame.Buttons
{
    public abstract class MenuButton : MonoBehaviour
    {
        [SerializeField] protected ScreenSide _screenSide;
        [SerializeField] private int _showOrder = 1;

        private float _showSpeed = 0.2f;
        private float _hideSpeed = 0.5f;
        private Vector3 _normalLocalPos;
        private RectTransform _rectTransform;

        private Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _rectTransform = GetComponent<RectTransform>();
            _normalLocalPos = _rectTransform.anchoredPosition;
        }

        public void Show()
        {
            _button.interactable = true;
            _rectTransform.DOAnchorPos(_normalLocalPos, _showOrder * _showSpeed).SetEase(Ease.OutExpo);
        }

        public void Hide()
        {
            Vector3 moveVector;
            _button.interactable = false;
            switch (_screenSide)
            {
                case ScreenSide.Left:
                    moveVector = Vector3.left;
                    break;
                case ScreenSide.Right:
                    moveVector = Vector3.right;
                    break;
                case ScreenSide.Bottom:
                    moveVector = Vector3.down;
                    break;
                default:
                    moveVector = Vector3.zero;
                    break;
            }
            _rectTransform.DOAnchorPos(_normalLocalPos + (moveVector * 1000), _hideSpeed);
        }
    }

    public enum ScreenSide
    {
        Left,
        Bottom,
        Right
    }
}