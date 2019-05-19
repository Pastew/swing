using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public UnityEvent clockTickEvent;

    [Tooltip("Select if clock should start by itself automatically after creation")]
    public bool autoStart = false;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (clockTickEvent == null)
            clockTickEvent = new UnityEvent();
    }

    void Start()
    {
        if (autoStart)
            StartClock();
        else
            StopClock();
    }

    public void SubscribeToClockTick(UnityAction clockTickSubscriber)
    {
        clockTickEvent.AddListener(clockTickSubscriber);
    }

    // This is invoked by animation
    public void ClockTick()
    {
        clockTickEvent.Invoke();
    }

    public void StopClock()
    {
        animator.enabled = false;
    }

    public void StartClock()
    {
        animator.SetTrigger("Restart");
        animator.enabled = true;
    }
}
