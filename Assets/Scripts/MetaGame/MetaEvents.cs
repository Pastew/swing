using System;
using UnityEngine;

namespace MetaGame
{
    public class MetaEvents : MonoBehaviour
    {
        public static Action ShowMenuEvent;
        public static Action<int> UpdateCoinsEvent;
        public static Action PlayButtonPressedEvent;
        public static Action ReplayButtonPressedEvent;
        public static Action LevelResultShown;
    }
}