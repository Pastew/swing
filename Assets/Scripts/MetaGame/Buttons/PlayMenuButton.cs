using UnityEngine.UI;

namespace MetaGame.Buttons
{
    public class PlayMenuButton : MenuButton
    {
        protected override void Awake()
        {
            base.Awake();
            GetComponent<Button>().onClick.AddListener(() => MetaEvents.PlayButtonPressedEvent());
        }
    }
}