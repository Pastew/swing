using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public bool updateColorsInUpdate = false;

    public Color cameraColor;

    GameObject goalPrefab;
    public Color goalColor;

    GameObject heroPrefab;
    public Color heroColor;

    GameObject bonusPointPrefab;
    public Color starColor;

    Material swingEdgeMaterial;
    Material swingFillMaterial;
    public Color swingEdgeMaterialColor;
    public Color swingFillMaterialColor;

    private void Awake()
    {
        swingEdgeMaterial = (Resources.Load("TerrainMaterials/SwingEdgeMaterial") as Material);
        swingFillMaterial = (Resources.Load("TerrainMaterials/SwingFillMaterial") as Material);
        heroPrefab = (Resources.Load("Prefabs/Hero") as GameObject);
        goalPrefab = (Resources.Load("Prefabs/Goal") as GameObject);
        bonusPointPrefab = (Resources.Load("Prefabs/BonusPoint") as GameObject);
    }

    private void Start()
    {
        UpdateColors();
    }

    private void Update()
    {
        if (Debug.isDebugBuild && updateColorsInUpdate)
        {
            UpdateColors();
        }
    }

    private void UpdateColors()
    {
        Camera.main.backgroundColor = cameraColor;

        swingEdgeMaterial.color = swingEdgeMaterialColor;
        swingFillMaterial.color = swingFillMaterialColor;

        if (Debug.isDebugBuild && updateColorsInUpdate && FindObjectOfType<Hero>())
        {
            FindObjectOfType<Hero>().GetComponent<SpriteRenderer>().color = heroColor;
        }
        else
        {
            heroPrefab.GetComponent<SpriteRenderer>().color = heroColor;
        }

        if (Debug.isDebugBuild && updateColorsInUpdate && FindObjectOfType<Goal>())
        {
            FindObjectOfType<Goal>().GetComponent<SpriteRenderer>().color = goalColor;
        }
        else
        {
            goalPrefab.GetComponent<SpriteRenderer>().color = goalColor;
        }

        if (Debug.isDebugBuild && updateColorsInUpdate && FindObjectOfType<BonusPoint>())
        {
            FindObjectOfType<BonusPoint>().GetComponent<SpriteRenderer>().color = starColor;
        }
        else
        {
            bonusPointPrefab.GetComponent<SpriteRenderer>().color = starColor;
        }
    }
}
