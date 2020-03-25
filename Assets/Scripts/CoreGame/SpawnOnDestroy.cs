using UnityEngine;

namespace CoreGame
{
    public class SpawnOnDestroy : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToSpawnPrefab;
        private bool _isQuitting;

        void OnApplicationQuit()
        {
            _isQuitting = true;
        }
        
        void OnDestroy()
        {
            if (_isQuitting)
                return;
            
            Instantiate(_objectToSpawnPrefab, transform.position, Quaternion.identity);
        }
    }
}
