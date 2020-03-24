using System;
using UnityEngine;

namespace CoreGame
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private  GameObject _heroPrefab;
        
        private GameObject _currentLevel;
        private int _currentLevelIndex;

        public void LoadLevel(int levelIndex)
        {
            Destroy(_currentLevel);
            
            _currentLevelIndex = levelIndex;
            string path = "Levels/Level_" + levelIndex;
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
            GameObject hero = Instantiate(_heroPrefab, GetStartPosition(), Quaternion.identity);
            hero.transform.parent = _currentLevel.transform;
        }
    
        private Vector3 GetStartPosition()
        {
            return _currentLevel.GetComponentInChildren<StartPosition>().transform.position;
        }

        public void ReloadCurrentLevel()
        {
            LoadLevel(_currentLevelIndex);
        }
    }
}
