using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private StarsUI starsUI;

    public Color cameraColor;

    public Color starFullColor;
    public Color starEmptyColor;

    public Color swingEdgeMaterialColor;
    public Color swingFillMaterialColor;


    Material swingEdgeMaterial;
    Material swingFillMaterial;

    private Dictionary<string, string> palette;

    private void Awake()
    {
        starsUI = FindObjectOfType<StarsUI>();
        swingEdgeMaterial = (Resources.Load("TerrainMaterials/SwingEdgeMaterial") as Material);
        swingFillMaterial = (Resources.Load("TerrainMaterials/SwingFillMaterial") as Material);
    }

    private void Start()
    {
        UpdateColors();
    }

    private void UpdateColors()
    {
        Camera.main.backgroundColor = cameraColor;

        starsUI.starEmptyColor = starEmptyColor;
        starsUI.starFullColor = starFullColor;

        swingEdgeMaterial.color = swingEdgeMaterialColor;
        swingFillMaterial.color = swingFillMaterialColor;
    }
}
