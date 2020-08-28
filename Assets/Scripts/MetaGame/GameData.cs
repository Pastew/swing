using System;
using System.Collections.Generic;

namespace MetaGame
{
    [Serializable]
    public class GameData
    {
        public int Coins;
        public List<int> UnlockedWorlds;
        
        // level not in dictionary = level locked
        // 0, 1, 2, 3 = level unlocked + stars collected
        public Dictionary<int, int> LevelsProgress;

        public GameData()
        {
            Coins = 0;
            UnlockedWorlds = new List<int> {0};
            LevelsProgress =  new Dictionary<int, int>
            {
                {0,0}
            };
        }
    }
}
