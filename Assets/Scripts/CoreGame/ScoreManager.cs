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
            LevelScore._stars++;
        }

        public void OnUserClicked()
        {
            LevelScore._clicks++;
        }

        public void StopTimer()
        {
            print("StopTimer");

            LevelScore._seconds = Time.time - _startTime;
        }

        public void StartTimer()
        {
            print("StartTimer");
            _startTime = Time.time;
        }
    }
}