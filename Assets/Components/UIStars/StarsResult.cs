using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components.UIStars
{
    public class StarsResult : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _starCollectedUIPrefab;
        [SerializeField] private GameObject _starEmptyUIPrefab;

        [Header("Show")]
        [SerializeField] private float _delayBetweenStars;
        private List<GameObject> _starsAnchors;

        private void Awake()
        {
            _starsAnchors = new List<GameObject>();
            for (int i = 0; i < 3; ++i)
                _starsAnchors.Add(transform.GetChild(i).gameObject);
        }

        public void ShowStars(int stars)
        {
            for (int i = 0; i < 3; ++i)
            {
                GameObject prefabToInstantiate = i < stars
                    ? _starCollectedUIPrefab
                    : _starEmptyUIPrefab;

                StartCoroutine(DelayedInstantiate(prefabToInstantiate, _starsAnchors[i].transform,
                    _delayBetweenStars * i));
            }
        }

        IEnumerator DelayedInstantiate(GameObject prefab, Transform parent, float delay)
        {
            yield return new WaitForSeconds(delay);

            Instantiate(prefab, parent);
        }
    }
}