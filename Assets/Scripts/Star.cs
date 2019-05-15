using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
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

    internal void OnCollected()
    {
        FindObjectOfType<ScoreManager>().BonusPointCollected();
        Destroy(gameObject);
    }
}
