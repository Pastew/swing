using System;
using UnityEngine;

namespace MetaGame
{
    public class MetaEvents : MonoBehaviour
    {
        public static Action ShowMenuEvent;
        public static Action<int> UpdateCoinsEvent;
        public static Action NextLevelButtonPressedEvent;
        public static Action ReplayButtonPressedEvent;
        public static Action LevelResultShownEvent;
        public static Action LevelsButtonPressedEvent;
        public static Action MainMenuButtonPressedEvent;
    }
}