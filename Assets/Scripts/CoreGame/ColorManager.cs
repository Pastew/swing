using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Color cameraColor;

    private GameObject goalPrefab;
    [SerializeField] private Color goalColor;

    private GameObject heroPrefab;
    [SerializeField] private Color heroColor;

    private GameObject starPrefab;
    [SerializeField] private Color starColor;

    // private Material edgeMaterial;
    // private Material fillMaterial;
    // [SerializeField] private Color edgeMaterialColor;
    // [SerializeField] private Color fillMaterialColor;

    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        // edgeMaterial = Resources.Load("TerrainMaterials/SwingEdgeMaterial") as Material;
        // fillMaterial = Resources.Load("TerrainMaterials/SwingFillMaterial") as Material;
        heroPrefab = Resources.Load("Prefabs/Hero") as GameObject;
        goalPrefab = Resources.Load("Prefabs/Goal") as GameObject;
        starPrefab = Resources.Load("Prefabs/Star") as GameObject;
    }

    private void Start()
    {
        UpdateColors();
    }


    private void UpdateColors()
    {
        camera.backgroundColor = cameraColor;

        // edgeMaterial.color = edgeMaterialColor;
        // fillMaterial.color = fillMaterialColor;

        if (FindObjectOfType<Hero>())
            FindObjectOfType<Hero>().GetComponent<SpriteRenderer>().color = heroColor;
        else
            heroPrefab.GetComponent<SpriteRenderer>().color = heroColor;
        
        if (FindObjectOfType<Goal>())
            FindObjectOfType<Goal>().GetComponent<SpriteRenderer>().color = goalColor;
        else
            goalPrefab.GetComponent<SpriteRenderer>().color = goalColor;
        
        if (FindObjectOfType<Star>())
            FindObjectOfType<Star>().GetComponent<SpriteRenderer>().color = starColor;
        else
            starPrefab.GetComponent<SpriteRenderer>().color = starColor;
    }
}