using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class LastWorldButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => MetaEvents.LastWorldButtonPressedEvent());
    }
}
