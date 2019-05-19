using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Think something better for this class...
public class PointsPresenter : MonoBehaviour
{
    public GameObject timeTickPointPrefab, bonusPointPrefab, clickPointPrefab;
    public GameObject tickPointsSpawnPosition;

    public enum PointType { timeTickPoint, bonusPoint, clickPoint };

    private Clock clock;
    private GameManager gameManager;

    private void Awake()
    {
        clock = FindObjectOfType<Clock>();
        clock.SubscribeToClockTick(OnClockTick);

        gameManager = FindObjectOfType<GameManager>();
        gameManager.SubscribeToBonusPointCollected(OnBonusPointCollected);
    }

    private void OnBonusPointCollected(BonusPoint bonusPoint)
    {
        throw new NotImplementedException();
    }

    public void SpawnPoint(Vector3 pos, PointType pointType)
    {
        switch (pointType)
        {
            case PointType.bonusPoint:
                Spawn(pos, bonusPointPrefab);
                break;
            case PointType.timeTickPoint:
                Spawn(pos, timeTickPointPrefab);
                break;
            case PointType.clickPoint:
                Spawn(pos, clickPointPrefab);
                break;
        }
    }

    private void OnClockTick()
    {
        Spawn(Vector3.zero, timeTickPointPrefab);
    }

    private void Spawn(Vector3 pos, GameObject pointPrefab)
    {
        GameObject pointGO = Instantiate(pointPrefab, transform);
        pointGO.GetComponent<RectTransform>().position = pos;
        Destroy(pointGO, 0.8f);
    }
}
