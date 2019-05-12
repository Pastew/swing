using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSForcer : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
