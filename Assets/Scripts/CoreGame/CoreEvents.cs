using System;
using UnityEngine;

namespace CoreGame
{
    public class CoreEvents : MonoBehaviour
    {
        public static Action<Vector2> UserUsedHookEvent;
        public static Action<Star> StarCollectedEvent;
        public static Action<Vector2> HeroDiedAction;
        public static Action HeroReachedGoalEvent;
        public static Action LevelLoadedEvent;
        public static Action CountdownFinishedEvent;
    }
}