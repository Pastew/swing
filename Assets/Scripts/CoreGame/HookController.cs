using System;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGame
{
    public class HookController : MonoBehaviour
    {
        private GameObject _hookGO;
        private bool _canUseHook = false;

        private Camera _camera;

        private void Awake()
        {
            _hookGO = transform.GetChild(0).gameObject;
            _hookGO.SetActive(false);
            _camera = Camera.main;
        }

        void Update()
        {
            if (!_canUseHook)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                _hookGO.transform.position = GetNewHookPosition();
                SetActiveHook(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                SetActiveHook(false);
            }
        }

        public void SetCanUseHook(bool newValue)
        {
            _canUseHook = newValue;
        }

        public void SetActiveHook(bool active)
        {
            if (_hookGO)
                _hookGO.SetActive(active);
        }

        private Vector3 GetNewHookPosition()
        {
            Vector3 newHookPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(newHookPos.x, newHookPos.y, 0);
        }
    }
}