using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => MetaEvents.MainMenuButtonPressedEvent());
    }
}
