using System.Collections.Generic;
using UnityEngine;

namespace MetaGame
{
    public class MetaGameValues : MonoBehaviour
    {
        public List<Sprite> WorldThumbnails;
        public List<string> WorldNames;

        public const int MaxPossibleStarsPerLevel = 3;
        public const int LevelsPerWorld = 10;
    }
}