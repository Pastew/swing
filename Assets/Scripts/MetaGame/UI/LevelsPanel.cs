using System.Collections.Generic;
using UnityEngine;

namespace MetaGame
{
    public class LevelsPanel : UIPanel
    {
        [SerializeField] private List<LevelButton> _levelButtons;
        private GameSaveManager _gameSaveManager;

        public override void Awake()
        {
            base.Awake();
            _gameSaveManager = FindObjectOfType<GameSaveManager>();
        }

        public void Setup(int worldIndex)
        {
            int firstWorldLevelIndex = worldIndex * 10;
            for (int i = 0; i < _levelButtons.Count; i++)
            {
                int levelIndex = firstWorldLevelIndex + i;
                int starsCollectedCount = GetStarsForLevel(levelIndex);
                _levelButtons[i].Setup(levelIndex, starsCollectedCount);
            }
        }

        private int GetStarsForLevel(int levelIndex)
        {
            try
            {
                return _gameSaveManager.GameSave.LevelsStars[levelIndex];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }
    }
}