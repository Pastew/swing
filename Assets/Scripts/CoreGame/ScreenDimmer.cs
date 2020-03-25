﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGame
{
    public class ScreenDimmer : MonoBehaviour
    {
        private Graphic _image;

        private void Awake()
        {
            _image = GetComponent<Graphic>();
        }

        public Tweener Dim(bool dim, float delay = 0, float duration = 0.5f)
        {
            return _image.DOFade(dim ? 1 : 0, duration)
                .SetEase(dim ? Ease.OutExpo : Ease.InExpo)
                .SetDelay(delay);
        }
    }
}