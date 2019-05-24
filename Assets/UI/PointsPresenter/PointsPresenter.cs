using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Think something better for this class...
public class PointsPresenter : MonoBehaviour
{
    public GameObject timeTickPointPrefab, bonusPointPrefab, clickPointPrefab;

    public enum PointType { timeTickPoint, bonusPoint, clickPoint };

    private Clock clock;

    private void Awake()
    {
        clock = FindObjectOfType<Clock>();
        clock.SubscribeToClockTick(OnClockTick);
    }

    void Start()
    {
        GameManager.instance.SubscribeToBonusPointCollected(OnBonusPointCollected);
    }

    private void OnBonusPointCollected(BonusPoint bonusPoint)
    {
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(bonusPoint.transform.position);

        GameObject pointGO = Instantiate(bonusPointPrefab, transform);
        pointGO.GetComponent<RectTransform>().anchorMin = viewportPoint;
        pointGO.GetComponent<RectTransform>().anchorMax = viewportPoint;
        Destroy(pointGO, 0.8f);
    }

    private void OnClockTick()
    {
        Vector2 pos = clock.GetComponent<RectTransform>().position;
        GameObject pointGO = Instantiate(timeTickPointPrefab, transform);
        pointGO.GetComponent<RectTransform>().position = pos;
    }
}
