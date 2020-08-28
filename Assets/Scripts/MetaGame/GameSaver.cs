using UnityEngine;

namespace MetaGame
{
    public class GameSaver
    {
        private const string GameSaveKey = "gameSave";

        public static void Save(GameSave save)
        {
            string json = JsonUtility.ToJson(save);
            PlayerPrefs.SetString(GameSaveKey, json);
            PlayerPrefs.Save();
            Debug.Log($"Saved game: {json}");
        }
        
        public static GameSave Load()
        {
            if (!SaveExists())
                return null;
            
            string json = PlayerPrefs.GetString(GameSaveKey);
            Debug.Log($"Loaded GameSave: {json}");
            return JsonUtility.FromJson<GameSave>(json);
        }
        
        public static bool SaveExists()
        {
            return PlayerPrefs.HasKey(GameSaveKey);
        }
    }
}