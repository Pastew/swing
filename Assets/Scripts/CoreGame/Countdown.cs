using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGame
{
    public class Countdown : MonoBehaviour
    {
        [Tooltip("In seconds")] private int _countdownTicks = 4;
        private float _oneCountdownLength = 0.5f;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void StartCountdown()
        {
            StartCoroutine(CountdownEnumerator(_countdownTicks));
        }

        IEnumerator CountdownEnumerator(int seconds)
        {
            int count = seconds;

            while (count > 0)
            {
                SetCounterCanvasText(count.ToString());
                yield return new WaitForSeconds(_oneCountdownLength);
                count--;
            }

            SetCounterCanvasText("");
            CoreEvents.CountdownFinishedEvent();
        }

        private void SetCounterCanvasText(string text)
        {
            _text.text = text;
        }
    }
}