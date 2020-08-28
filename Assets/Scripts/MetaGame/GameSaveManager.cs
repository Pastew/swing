using UnityEngine;

namespace MetaGame
{
    public class GameSaveManager : MonoBehaviour
    {
        private GameSave _gameSave;
        private MetaGameValues _metaGameValues;

        public GameSave GameSave => _gameSave;

        private void Awake()
        {
            _metaGameValues = FindObjectOfType<MetaGameValues>();
            
            _gameSave = GameSaver.Load();
            if (_gameSave == null)
            {
                _gameSave = CreateEmptyGameSave();
                Save();
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.X))
                PlayerPrefs.DeleteAll();
        }

        public void Save()
        {
            GameSaver.Save(_gameSave);
        }

        public int AddCoins(int purchasedCoinsValue)
        {
            _gameSave.Coins += purchasedCoinsValue;
            Save();
            return _gameSave.Coins;
        }

        private GameSave CreateEmptyGameSave()
        {
            int levelsCount = _metaGameValues.TotalLevelCount;
            return new GameSave(levelsCount);
        }
    }
}