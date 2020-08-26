using UnityEngine;
using UnityEngine.UI;

namespace MetaGame
{
    public class LevelsMenuButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => MetaEvents.LevelsButtonPressedEvent());
        }
    }
}