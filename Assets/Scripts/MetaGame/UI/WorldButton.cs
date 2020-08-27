using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class WorldButton : MonoBehaviour
{
    [SerializeField] private Text _levelsRangeText;
    [SerializeField] private Text _starsCollectedText;
    [SerializeField] private Text _worldNameText;
    [SerializeField] private Image _worldThumbnailImage;

    private int _worldIndex;

    protected void Start()
    {
        _worldIndex = transform.GetSiblingIndex();
        int firstWorldLevelNumber = _worldIndex * 10 + 1;
        int lastWorldLevelNumber = firstWorldLevelNumber + 9;

        int collectedStars = GetCollectedStars(_worldIndex);
        int maxPossibleStarsPerWorld = GetMaxPossibleStarsPerWorld();
        
        _levelsRangeText.text = $"{firstWorldLevelNumber} - {lastWorldLevelNumber}";
        _starsCollectedText.text = $"{collectedStars}/{maxPossibleStarsPerWorld}";
        GetComponent<Button>().onClick.AddListener(() => { MetaEvents.WorldButtonPressedEvent(_worldIndex); });

        MetaGameValues metaGameValues = FindObjectOfType<MetaGameValues>();

        try
        {
            _worldNameText.text = metaGameValues.WorldNames[_worldIndex];
        }
        catch
        {
            _worldNameText.text = $"World {_worldIndex + 1}";
        }

        try
        {
            _worldThumbnailImage.sprite = metaGameValues.WorldThumbnails[_worldIndex];
        }
        catch
        {
            _worldThumbnailImage.sprite = metaGameValues.WorldThumbnails[0];
        }
    }

    private int GetMaxPossibleStarsPerWorld()
    {
        return MetaGameValues.MaxPossibleStarsPerLevel * MetaGameValues.LevelsPerWorld;
    }

    private int GetCollectedStars(int worldIndex)
    {
        return Random.Range(0, 31);
    }
}