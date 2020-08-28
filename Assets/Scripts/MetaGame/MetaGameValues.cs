using System.Collections.Generic;
using UnityEngine;

namespace MetaGame
{
    public class MetaGameValues : MonoBehaviour
    {
        public List<Sprite> WorldThumbnails;
        public List<string> WorldNames;

        public int MaxPossibleStarsPerLevel = 3;
        public int WorldsCount = 10;
        public int LevelsPerWorld = 10;
        public int TotalLevelCount => WorldsCount * LevelsPerWorld;

        [Range(0, 1)] public float StarsRequiredFactor = 0.6f;

        public int GetStarsRequiredForWorld(int worldIndex)
        {
            return (int) Mathf.Floor(StarsRequiredFactor * MaxPossibleStarsPerLevel * LevelsPerWorld * worldIndex);
        }
    }
}