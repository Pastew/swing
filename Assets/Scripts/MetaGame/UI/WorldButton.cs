using System.Collections;
using System.Collections.Generic;
using MetaGame;
using UnityEngine;
using UnityEngine.UI;

public class WorldButton : MonoBehaviour
{
    [SerializeField] private int _worldId;
    
    protected void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            MetaEvents.WorldButtonPressedEvent(_worldId);
        });
    }
}
