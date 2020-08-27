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
        public static Action<int> LoadLevelEvent;

        public static Action WorldsPanelButtonPressedEvent;
        public static Action<int> WorldButtonPressedEvent;
        public static Action LastWorldButtonPressedEvent;
    }
}