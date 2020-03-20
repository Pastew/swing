using UnityEngine;

namespace MetaGame
{
    public class GameSaveManager : MonoBehaviour
    {
        public static GameSaveManager instance;

        private GameSave gameSave;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            gameSave = LoadGameSave();
            if (gameSave == null)
                gameSave = CreateEmptyGameSave();
        }

        private GameSave LoadGameSave()
        {
            return null;
        }

        internal int AddCoins(int purchasedCoinsValue)
        {
            gameSave.coins += purchasedCoinsValue;
            SaveGameSave();
            return gameSave.coins;
        }

        private void SaveGameSave()
        {
            print("Save game save stub");
        }

        private GameSave CreateEmptyGameSave()
        {
            GameSave gs = new GameSave();

            return gs;
        }

    }
}
