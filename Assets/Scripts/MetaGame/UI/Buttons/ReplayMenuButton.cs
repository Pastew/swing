using UnityEngine;
using UnityEngine.UI;

namespace MetaGame
{
    public class ReplayMenuButton : MonoBehaviour
    {
        protected void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => MetaEvents.ReplayButtonPressedEvent());
        }
    }
}