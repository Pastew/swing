using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsUI : MonoBehaviour
{
    private Image[] stars;

    private Sprite starFull;
    private Sprite starEmpty;

    void OnEnable()
    {
        stars = new Image[3];
        for (int i = 0; i < 3; ++i)
           stars[i] = transform.Find("Star" + (i + 1)).GetComponent<Image>();

        starEmpty = Resources.Load<Sprite>("Images/starEmpty") as Sprite;
        starFull = Resources.Load<Sprite>("Images/star") as Sprite;
    }

    internal void ShowStars(int collectedStars)
    {
        print("Showing stars: " + collectedStars);
        for (int i = 0; i < 3; i++)
        {
            stars[i].sprite = (collectedStars >= i + 1 ? starFull : starEmpty);
        }
    }
}
