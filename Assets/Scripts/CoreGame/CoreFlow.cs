using Shared;
using UnityEngine;

namespace CoreGame
{
    public class CoreFlow : MonoBehaviour
    {
        private Countdown _countdown;
        private LevelLoader _levelLoader;
        private ScoreManager _scoreManager;
        private HookController _hookController;
        private SharedFlow _sharedFlow;

        private void Awake()
        {
            _sharedFlow = FindObjectOfType<SharedFlow>();
            _countdown = FindObjectOfType<Countdown>();
            _levelLoader = FindObjectOfType<LevelLoader>();
            _hookController = FindObjectOfType<HookController>();
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Start()
        {
            CoreEvents.LevelLoadedEvent += OnLevelLoaded;
            CoreEvents.CountdownFinishedEvent += OnCountdownFinished;
            
            CoreEvents.UserUsedHookEvent += OnUserUsedHookEvent;
            CoreEvents.StarCollectedEvent += OnStarCollected;
            CoreEvents.HeroReachedGoalEvent += OnHeroReachedGoal;
            
            CoreEvents.HeroDiedAction += OnHeroDeath;
        }

        public void LoadLevel(int levelIndex)
        {
            _levelLoader.LoadLevel(levelIndex);
            _scoreManager.ResetScore();
        }

        private void OnLevelLoaded()
        {
            _countdown.StartCountdown();
        }

        private void OnCountdownFinished()
        {
            FindObjectOfType<Hero>().Activate();
            _hookController.SetCanUseHook(true);
            _scoreManager.StartTimer();
        }

        private void OnStarCollected(Star star)
        {
            _scoreManager.OnStarCollected();
            Destroy(star.gameObject);
        }

        private void OnHeroReachedGoal()
        {
            _scoreManager.StopTimer();
            _sharedFlow.LevelFinished(_scoreManager.LevelScore);
            _hookController.SetActiveHook(false);
            _hookController.SetCanUseHook(false);
        }

        private void OnHeroDeath(Vector2 vector2)
        {
            _levelLoader.ReloadCurrentLevel();
            _hookController.SetActiveHook(false);
        }

        private void OnUserUsedHookEvent(Vector2 cliclPos)
        {
            _scoreManager.OnUserClicked();
        }
    }
}