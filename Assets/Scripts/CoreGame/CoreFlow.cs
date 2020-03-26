using DG.Tweening;
using Shared;
using UnityEngine;

namespace CoreGame
{
    public class CoreFlow : MonoBehaviour
    {
        private Countdown _countdown;
        private LevelManager _levelManager;
        private ScoreManager _scoreManager;
        private HookController _hookController;
        private SharedFlow _sharedFlow;
        private CameraSlider _cameraSlider;
        private CameraGoalMoveEffect _cameraGoalMoveEffect;
        private ScreenDimmer _screenDimmer;

        private void Awake()
        {
            _sharedFlow = FindObjectOfType<SharedFlow>();
            _countdown = FindObjectOfType<Countdown>();
            _levelManager = FindObjectOfType<LevelManager>();
            _hookController = FindObjectOfType<HookController>();
            _scoreManager = FindObjectOfType<ScoreManager>();
            _cameraSlider = FindObjectOfType<CameraSlider>();
            _cameraGoalMoveEffect = FindObjectOfType<CameraGoalMoveEffect>();
            _screenDimmer = FindObjectOfType<ScreenDimmer>();
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
            _levelManager.DestroyCurrentLevel(); //TODO: Remove
            _levelManager.LoadLevel(levelIndex);
            _scoreManager.ResetScore();
            _cameraSlider.SlideOutInstant();
        }

        private void OnLevelLoaded()
        {
            _cameraSlider.SlideIn().OnComplete(() => _countdown.StartCountdown());
        }

        private void OnCountdownFinished()
        {
            FindObjectOfType<Hero>().Activate();
            _hookController.SetCanUseHook(true);
            _scoreManager.StartTimer();
        }

        private void OnStarCollected(Vector2 pos)
        {
            _scoreManager.OnStarCollected();
        }

        private void OnHeroReachedGoal()
        {
            _scoreManager.StopTimer();
            _hookController.SetCanUseHook(false);
            _hookController.SetActiveHook(false);

            //Destroy(FindObjectOfType<Hero>().gameObject, 0.3f);
            Sequence seq = DOTween.Sequence();
            seq.Append(_cameraGoalMoveEffect.MoveToGoal());
            seq.Append(_screenDimmer.Dim(true, 0f, 0f));
            seq.AppendCallback(() => _levelManager.DestroyCurrentLevel());
            seq.Append(_cameraSlider.SlideOut());
            seq.Join(_screenDimmer.Dim(false));
            seq.AppendCallback(() => _sharedFlow.LevelFinished(_scoreManager.LevelScore));
            seq.Play();
        }

        private void OnHeroDeath(Vector2 vector2)
        {
            _hookController.SetActiveHook(false);
            _hookController.SetCanUseHook(false);

            _screenDimmer.Dim(true, 0.7f).OnComplete(() =>
            {
                _levelManager.DestroyCurrentLevel();
                _levelManager.ReloadCurrentLevel();
                _scoreManager.ResetScore();
                _screenDimmer.Dim(false);
            });
        }

        private void OnUserUsedHookEvent(Vector2 clickPos)
        {
            _scoreManager.OnUserClicked();
        }
    }
}