using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public bool updateColorsInUpdate = false;

    public Color cameraColor;

    GameObject goalPrefab;
    public Color goalColor;

    GameObject heroPrefab;
    public Color heroColor;

    GameObject starPrefab;
    public Color starColor;

    Material edgeMaterial;
    Material fillMaterial;
    public Color edgeMaterialColor;
    public Color fillMaterialColor;

    private void Awake()
    {
        edgeMaterial = Resources.Load("TerrainMaterials/SwingEdgeMaterial") as Material;
        fillMaterial = Resources.Load("TerrainMaterials/SwingFillMaterial") as Material;
        heroPrefab = Resources.Load("Prefabs/Hero") as GameObject;
        goalPrefab = Resources.Load("Prefabs/Goal") as GameObject;
        starPrefab = Resources.Load("Prefabs/BonusPoint") as GameObject;
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

        edgeMaterial.color = edgeMaterialColor;
        fillMaterial.color = fillMaterialColor;

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

        if (Debug.isDebugBuild && updateColorsInUpdate && FindObjectOfType<Star>())
        {
            FindObjectOfType<Star>().GetComponent<SpriteRenderer>().color = starColor;
        }
        else
        {
            starPrefab.GetComponent<SpriteRenderer>().color = starColor;
        }
    }
}
