using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2f;

    float minX = -7, maxX = 7;
    float minY = -6, maxY = 6;

    public float maxCamX = 1, maxCamY = 1;

    private Vector3 startingPos;

    private void Awake()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        Hero target = FindObjectOfType<Hero>();

        if (target == null)
            return;


        Vector3 newPosition = new Vector3();
        newPosition.z = -10;

        newPosition.x = remap(minX, maxX, -maxCamX, maxCamX, target.transform.position.x);
        newPosition.y = remap(minY, maxY, -maxCamX, maxCamY, target.transform.position.y);

        transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);
    }

    public float remap(float a0, float a1, float b0, float b1, float a)
    {
        return b0 + (b1 - b0) * ((a - a0) / (a1 - a0));
    }

    public void Reset()
    {
        transform.position = startingPos;
    }
}
