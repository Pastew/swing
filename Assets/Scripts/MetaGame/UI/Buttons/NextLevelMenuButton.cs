using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace MetaGame
{
    public class NextLevelMenuButton : MonoBehaviour
    {
        protected void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                MetaEvents.NextLevelButtonPressedEvent();
            });
        }
    }
}