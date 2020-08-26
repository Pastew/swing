using Shared;
using UnityEngine;

namespace CoreGame
{
    public class ScoreManager : MonoBehaviour
    {
        public LevelScore LevelScore { get; set; }

        private float _startTime;

        public void ResetScore()
        {
            LevelScore = new LevelScore();
        }

        public void OnStarCollected()
        {
            LevelScore.Stars++;
        }

        public void OnUserClicked()
        {
            LevelScore.Clicks++;
        }

        public void StopTimer()
        {
            print("StopTimer");

            LevelScore.Seconds = Time.time - _startTime;
        }

        public void StartTimer()
        {
            print("StartTimer");
            _startTime = Time.time;
        }
    }
}