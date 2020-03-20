using UnityEngine;

namespace CoreGame
{
    public class FPSForcer : MonoBehaviour
    {
        void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}
