using UnityEngine;

namespace MetaGame
{
    public class GameSaveManager : MonoBehaviour
    {
        private GameData _gameData;

        public GameData GameData => _gameData;

        private void Awake()
        {
            _gameData = GameSaver.Load();
            if (_gameData == null)
            {
                _gameData = CreateEmptyGameSave();
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
            GameSaver.Save(_gameData);
        }

        public int AddCoins(int purchasedCoinsValue)
        {
            _gameData.Coins += purchasedCoinsValue;
            Save();
            return _gameData.Coins;
        }

        private GameData CreateEmptyGameSave()
        {
            return new GameData();
        }
    }
}