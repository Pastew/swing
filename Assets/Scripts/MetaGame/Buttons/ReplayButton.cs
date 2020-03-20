using UnityEngine;
using UnityEngine.UI;

namespace MetaGame.Buttons
{
    public class ReplayButton : MonoBehaviour, IButton
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => MetaEvents.ReplayButtonPressedEvent());
        }
    }
}