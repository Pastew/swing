using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    private int collectedStars;

    public int CollectedStars { get => collectedStars;}

    public void OnStarCollected(Vector3 position)
    {
        ++collectedStars;
    }

    internal void ResetStarsCounter()
    {
        collectedStars = 0;
    }
}
