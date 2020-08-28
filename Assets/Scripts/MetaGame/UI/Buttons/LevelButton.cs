using System;
using System.Collections.Generic;
using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Sprite _emptyStarSprite;
    [SerializeField] private Sprite _collectedStarSprite;

    [SerializeField] private Text _levelText;
    [SerializeField] private List<Image> _stars;

    private int _levelIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        MetaEvents.LoadLevelEvent(_levelIndex);
    }

    public void Setup(int levelIndex, int starsCollectedCount)
    {
        _levelIndex = levelIndex;
        _levelText.text = $"{levelIndex+1}";

        for (int i = 0; i < 3; i++)
        {
            _stars[i].sprite = i < starsCollectedCount ? _collectedStarSprite : _emptyStarSprite;
        }
    }
}