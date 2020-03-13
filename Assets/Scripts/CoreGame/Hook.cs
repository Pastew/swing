using UnityEngine;

public class Hook : MonoBehaviour
{
    private Hero hero;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void OnEnable()
    {
        hero = FindObjectOfType<Hero>();
        GetComponent<DistanceJoint2D>().connectedBody = hero.GetComponent<Rigidbody2D>();
        UpdateLine();
    }

    private void OnDisable()
    {
        hero.OnHookRelease();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hero.transform.position);
    }
}