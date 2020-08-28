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
                GameSaver.Save(_gameData);
            }
        }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.X))
                PlayerPrefs.DeleteAll();
        }

        private GameData CreateEmptyGameSave()
        {
            return  new GameData();
        }

        public int AddCoins(int purchasedCoinsValue)
        {
            _gameData.Coins += purchasedCoinsValue;
            GameSaver.Save(_gameData);
            return _gameData.Coins;
        }
    }
}