using UnityEngine;

public class FPSForcer : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
