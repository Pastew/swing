using System;
using UnityEngine;

namespace CoreGame
{
    public class CoreEvents : MonoBehaviour
    {
        public static Action<Vector2> UserUsedHookEvent;
        public static Action LevelLoadedEvent;
        public static Action CountdownFinishedEvent;
        public static Action<Vector2> StarCollectedEvent;
        public static Action HeroReachedGoalEvent;
        public static Action<Vector2> HeroDiedAction;
    }
}