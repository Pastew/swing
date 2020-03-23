using Shared;
using UnityEngine;

namespace MetaGame
{
    public class MetaFlow : MonoBehaviour
    {
        private UIManager _uiManager;
        private LevelManager _levelManager;

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
            _levelManager = FindObjectOfType<LevelManager>();
            MetaEvents.PlayButtonPressedEvent += () =>
            {
                _uiManager.HideMenu();
                _levelManager.LoadNextLevel();
            };

            MetaEvents.ReplayButtonPressedEvent += () =>
            {
                _uiManager.HideMenu();
                _levelManager.LoadCurrentLevel();
            };
        }

        void Start()
        {
            // _uiManager.ShowMenu();
        }

        public void OnLevelFinished(LevelScore levelScore)
        {
            _uiManager.ShowLevelResultsScreen(levelScore);

        }
    }
}