using System;
using MetaGame;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WorldButton : MonoBehaviour
{
    private MetaGameValues _metaGameValues;

    [SerializeField] private Text _levelsRangeText;
    [SerializeField] private Text _starsCollectedText;
    [SerializeField] private Text _worldNameText;
    [SerializeField] private Image _worldThumbnailImage;

    [Header("Locked world")] [SerializeField]
    private GameObject _locked;

    [SerializeField] private Text _requiredStarsText;

    private int _worldIndex;
    private Button _button;

    private void Awake()
    {
        _metaGameValues = FindObjectOfType<MetaGameValues>();
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { MetaEvents.WorldButtonPressedEvent(_worldIndex); });

        _worldIndex = transform.GetSiblingIndex();

        SetupPersistentData();
        SetupChangingWorldData();
    }

    private void Start()
    {
        _metaGameValues = FindObjectOfType<MetaGameValues>();
    }

    private void SetupPersistentData()
    {
        _requiredStarsText.text = $"{_metaGameValues.GetStarsRequiredForWorld(_worldIndex)}";

        int firstWorldLevelNumber = _worldIndex * 10 + 1;
        int lastWorldLevelNumber = firstWorldLevelNumber + 9;
        _levelsRangeText.text = $"{firstWorldLevelNumber} - {lastWorldLevelNumber}";

        try
        {
            _worldNameText.text = _metaGameValues.WorldNames[_worldIndex];
        }
        catch
        {
            _worldNameText.text = $"World {_worldIndex + 1}";
        }

        try
        {
            _worldThumbnailImage.sprite = _metaGameValues.WorldThumbnails[_worldIndex];
        }
        catch
        {
            _worldThumbnailImage.sprite = _metaGameValues.WorldThumbnails[0];
        }
    }

    private void SetupChangingWorldData()
    {
        int collectedStars = GetCollectedStars(_worldIndex);
        int maxPossibleStarsPerWorld = GetMaxPossibleStarsPerWorld();
        _starsCollectedText.text = $"{collectedStars}/{maxPossibleStarsPerWorld}";
    }

    private int GetMaxPossibleStarsPerWorld()
    {
        return _metaGameValues.MaxPossibleStarsPerLevel * _metaGameValues.LevelsPerWorld;
    }

    private int GetCollectedStars(int worldIndex)
    {
        return Random.Range(0, 31);
    }

    public void SetLocked(bool locked)
    {
        _locked.SetActive(locked);
        _button.interactable = !locked;
    }
}