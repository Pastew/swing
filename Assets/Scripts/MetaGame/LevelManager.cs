using Shared;
using UnityEngine;

namespace MetaGame
{
    public class LevelManager : MonoBehaviour
    {
        private int _currentLevelIndex;
        private SharedFlow _sharedFlow;

        private void Awake()
        {
            _sharedFlow = FindObjectOfType<SharedFlow>();
        }

        internal int GetCurrentLevelIndex()
        {
            return _currentLevelIndex;
        }
        
        public void LoadNextLevel()
        {
            _sharedFlow.LoadLevel(++_currentLevelIndex);
        }

        public void LoadCurrentLevel()
        {
            _sharedFlow.LoadLevel(_currentLevelIndex);
        }
    }
}
