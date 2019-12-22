using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance = null;

    private GameSave gameSave;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gameSave = LoadGameSave();
        if (gameSave == null)
            gameSave = FirstCreateGameSave();
    }

    private GameSave LoadGameSave()
    {
        GameSave gs = new GameSave();

        return gs;
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

    private GameSave FirstCreateGameSave()
    {
        GameSave gs = new GameSave();

        return gs;
    }

}
