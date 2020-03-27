using UnityEngine.UI;
using Utils;

namespace MetaGame.Buttons
{
    public class PlayMenuButton : MenuButton
    {
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Button>().onClick.AddListener(() =>
            {
                GetComponent<HearthBeatAnimation>().KillAnimation();
                MetaEvents.PlayButtonPressedEvent();
            });
        }
    }
}