using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsUI : MonoBehaviour
{
    // Childs
    private Image[] stars;

    // Resources
    private Sprite starFull;
    private Sprite starEmpty;

    void OnEnable()
    {
        stars = new Image[3];
        for (int i = 0; i < 3; ++i)
            stars[i] = transform.Find("Star" + (i + 1)).GetComponent<Image>();

        starEmpty = Resources.Load<Sprite>("Images/starUIEmpty") as Sprite;
        starFull = Resources.Load<Sprite>("Images/starUIFull") as Sprite;
    }

    internal void ShowStars(int collectedStars)
    {
        print("Showing stars: " + collectedStars);
        for (int i = 0; i < 3; i++)
        {
            if (collectedStars >= i + 1)
            {
                stars[i].sprite = starFull;
            }
            else
            {
                stars[i].sprite = starEmpty;
            }
        }

    }
}
