using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _test;

    private void Awake()
    {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            MetaEvents.WorldsPanelButtonPressedEvent();
            GetComponent<Button>().onClick.AddListener(() => _test.SetActive(true));
        });
    }
}
