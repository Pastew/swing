using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private Dictionary<string, string> palette;

    private StarsUI starsUI;

    private void Awake()
    {
        starsUI = FindObjectOfType<StarsUI>();
    }

    void Start()
    {
        palette = new Dictionary<string, string>();
        palette["starFullColor"] = "#fdfd96";
        palette["starEmptyColor"] = "#FFFFFF";

        UpdateColors();
    }

    private void UpdateColors()
    {
        ColorUtility.TryParseHtmlString(palette["starEmptyColor"], out starsUI.starEmptyColor);
        ColorUtility.TryParseHtmlString(palette["starFullColor"], out starsUI.starFullColor);
    }
}
