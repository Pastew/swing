using UnityEngine;

namespace CoreGame
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private float _seconds = 5;

        void Start()
        {
            Destroy(gameObject, _seconds);
        }
    }
}
