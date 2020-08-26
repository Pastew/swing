using System;
using UnityEngine;

namespace MetaGame
{
    public class MetaEvents : MonoBehaviour
    {
        public static Action<int> UpdateCoinsEvent;
        public static Action LevelResultShownEvent;
        
        public static Action MainMenuButtonPressedEvent;
        public static Action ReplayButtonPressedEvent;
        public static Action NextLevelButtonPressedEvent;
        
        public static Action WorldsSelectButtonPressedEvent;
        public static Action<int> WorldButtonPressedEvent;
        public static Action LastWorldButtonPressedEvent;
    }
}