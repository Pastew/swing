using System.Collections.Generic;
using UnityEngine;

namespace MetaGame
{
    public class LevelsPanel : UIPanel
    {
        [SerializeField] private List<LevelButton> _levelButtons;

        public void Setup(int worldIndex)
        {
            int firstWorldLevelNumber = worldIndex * 10 + 1;
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int levelIndex = firstWorldLevelNumber + i;
                int starsCollectedCount = GetStarsForLevel(levelIndex);
                _levelButtons[i].Setup(levelIndex, starsCollectedCount);
            }
        }

        private int GetStarsForLevel(int levelIndex)
        {
            //TODO: implement
            return Random.Range(0, 4);
        }
    }
}