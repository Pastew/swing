using CoreGame;
using UnityEngine;

public class Star : MonoBehaviour, ICollectable 
{
    private float rotateSpeed = 50f;

    private void Start()
    {
        transform.Rotate(Vector3.forward, Random.Range(0, 360));
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
