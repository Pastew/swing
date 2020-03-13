using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public LevelScore LevelScore { get; private set; }

    internal static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MetaGameManager.instance.SubscribeToBonusPointCollected(OnStarCollected);
        HookController.Instance.SubscribeToUserClicked(OnUserClicked);
    }

    public void ResetScore()
    {
        LevelScore = new LevelScore();
    }

    // Game events
    public void OnStarCollected(Star star)
    {
        LevelScore.stars++;
    }

    public void OnUserClicked(Vector2 pos)
    {
        LevelScore.clicks++;
    }
}
