using Shared;
using UnityEngine;

namespace CoreGame
{
    public class ScoreManager : MonoBehaviour
    {
        public LevelScore LevelScore { get; set; }

        private float _startTime;
        private float _levelTime;

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
            _levelTime = Time.time - _startTime;
        }

        public void StartTimer()
        {
            _startTime = Time.time;
        }
    }
}