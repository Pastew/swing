using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Hero hero;
    private LineRenderer lineRenderer;
    private Vector3 startPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        hero = FindObjectOfType<Hero>();
    }

    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    internal void ResetPosition()
    {
        transform.position = startPosition;
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
