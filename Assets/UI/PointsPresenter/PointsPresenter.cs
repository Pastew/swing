using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPresenter : MonoBehaviour
{
    public GameObject timeTickPointPrefab, bonusPointPrefab, clickPointPrefab;

    void Start()
    {
        GameManager.instance.SubscribeToBonusPointCollected(OnBonusPointCollected);
        Clock.instance.SubscribeToClockTick(OnClockTick);
        InputManager.instance.SubscribeToUserClicked(OnUserClicked);
    }

    private void OnUserClicked(Vector2 clickPos)
    {
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(clickPos);

        GameObject pointGO = Instantiate(clickPointPrefab, transform);
        pointGO.GetComponent<RectTransform>().anchorMin = viewportPoint;
        pointGO.GetComponent<RectTransform>().anchorMax = viewportPoint;
        //pointGO.GetComponent<RectTransform>().position = viewportPoint;

        Destroy(pointGO, 0.8f);
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
        Vector2 pos = Clock.instance.GetComponent<RectTransform>().position;
        GameObject pointGO = Instantiate(timeTickPointPrefab, transform);
        pointGO.GetComponent<RectTransform>().position = pos;
    }
}
