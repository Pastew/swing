using System;
using UnityEngine;

namespace CoreGame
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private  GameObject _heroPrefab;
        
        private GameObject _currentLevel;
        private int _currentLevelIndex;

        public void LoadLevel(int levelIndex)
        {
            _currentLevelIndex = levelIndex;
            int levelPrefabSuffix = levelIndex + 1;
            string path = "Levels/Level_" + levelPrefabSuffix;
            try
            {
                _currentLevel = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
            }
            catch (ArgumentException argEx)
            {
                Debug.LogError($"Level you're trying to load doesn't exist: {path}.");
                throw;
            }

            CreateHero();
            CoreEvents.LevelLoadedEvent();
        }
    
        private void CreateHero()
        {
            Instantiate(_heroPrefab, GetStartPosition(), Quaternion.identity);
        }
    
        private Vector3 GetStartPosition()
        {
            return _currentLevel.GetComponentInChildren<StartPosition>().transform.position;
        }

        public void ReloadCurrentLevel()
        {
            LoadLevel(_currentLevelIndex);
        }

        public void DestroyCurrentLevel()
        {
            Destroy(_currentLevel);
        }
    }
}
