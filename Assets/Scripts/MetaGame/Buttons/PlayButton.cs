using UnityEngine;
using UnityEngine.UI;

namespace MetaGame.Buttons
{
    public class PlayButton : MonoBehaviour, IButton
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => MetaEvents.PlayButtonPressedEvent());
        }
    }
}