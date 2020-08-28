using UnityEngine;

namespace MetaGame
{
    public class GameSaver
    {
        private const string GameSaveKey = "gameSave";

        public static void Save(GameData data)
        {
            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(GameSaveKey, json);
            PlayerPrefs.Save();
            Debug.Log($"Saved game: {json}");
        }
        
        public static GameData Load()
        {
            if (!SaveExists())
                return null;
            
            string json = PlayerPrefs.GetString(GameSaveKey);
            Debug.Log($"Loaded GameSave: {json}");
            return JsonUtility.FromJson<GameData>(json);
        }
        
        public static bool SaveExists()
        {
            return PlayerPrefs.HasKey(GameSaveKey);
        }
    }
}