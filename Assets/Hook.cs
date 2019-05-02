using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Hero hero;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        hero = FindObjectOfType<Hero>();
    }

    void OnEnable()
    {
        UpdateLine();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hero.transform.position);
    }
}
