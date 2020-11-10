using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPlayButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            MetaEvents.WorldsPanelButtonPressedEvent();
        });
    }
}
