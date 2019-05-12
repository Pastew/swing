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

    // Colors set by ColorManager
    public Color starFullColor;
    public Color starEmptyColor;

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
            if (collectedStars >= i + 1)
            {
                stars[i].sprite = starFull;
                stars[i].color = starFullColor;
            }
            else
            {
                stars[i].sprite = starEmpty;
                stars[i].color = starEmptyColor;
            }
        }

    }
}
