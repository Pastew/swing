using UnityEngine;

namespace CoreGame
{
    public class Star : MonoBehaviour 
    {
        private float rotateSpeed = 50f;
        [SerializeField] private GameObject _deathPrefab;

        private void Start()
        {
            transform.Rotate(Vector3.forward, Random.Range(0, 360));
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        public void DestroyStar()
        {
            Instantiate(_deathPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
