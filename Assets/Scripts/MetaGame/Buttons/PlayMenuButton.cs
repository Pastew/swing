using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace MetaGame.Buttons
{
    public class PlayMenuButton : MonoBehaviour
    {
        protected void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                GetComponent<HearthBeatAnimation>().KillAnimation();
                MetaEvents.PlayButtonPressedEvent();
            });
        }
    }
}