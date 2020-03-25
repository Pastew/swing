using UnityEngine;

namespace CoreGame
{
    public class SetActiveOnAwake : MonoBehaviour
    {
        [SerializeField] private bool _active;

        private void Awake()
        {
            gameObject.SetActive(_active);
        }
    }
}
