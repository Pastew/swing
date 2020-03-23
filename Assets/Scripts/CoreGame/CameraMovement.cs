using UnityEngine;

namespace CoreGame
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private float _minX = -7, _maxX = 7;
        private float _minY = -6, _maxY = 6;

        [SerializeField] private float _maxCamX = 1, _maxCamY = 1;

        private Vector3 _startingPos;

        private void Awake()
        {
            _startingPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            Hero target = FindObjectOfType<Hero>(); // TODO: Optimize

            if (target == null)
                return;

            Vector3 newPosition = new Vector3 {z = -10};

            var pos = target.transform.position;
            newPosition.x = Utils.MathUtils.Remap(_minX, _maxX, -_maxCamX, _maxCamX, pos.x);
            newPosition.y = Utils.MathUtils.Remap(_minY, _maxY, -_maxCamX, _maxCamY, pos.y);

            transform.position = Vector3.Slerp(transform.position, newPosition, _speed * Time.deltaTime);
        }

        public void Reset()
        {
            transform.position = _startingPos;
        }
    }
}