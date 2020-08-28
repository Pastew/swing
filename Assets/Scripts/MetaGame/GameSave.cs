using System;
using System.Collections.Generic;

namespace MetaGame
{
    [Serializable]
    public class GameSave
    {
        public int Coins;
        public List<int> UnlockedWorlds;
        public List<int> LevelsStars;

        public GameSave(int levelsCount)
        {
            Coins = 0;
            UnlockedWorlds = new List<int> {0};
            
            LevelsStars = new List<int>(levelsCount);
            for(int i = 0 ; i < levelsCount; ++i)
            {
                LevelsStars.Add(0);
            }
        }
    }
}
