using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public UnityEvent clockTickEvent;

    void Start()
    {
        if (clockTickEvent == null)
            clockTickEvent = new UnityEvent();
    }

    public void AddOnTickListener(UnityAction clockTickSubscriber)
    {
        clockTickEvent.AddListener(clockTickSubscriber);
    }

    // This is invoked by animation
    public void ClockTick()
    {
        clockTickEvent.Invoke();
        print("Tick");
    }
}
