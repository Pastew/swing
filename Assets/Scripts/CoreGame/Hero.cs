using UnityEngine;

namespace CoreGame
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 1.5f;
        [SerializeField] private GameObject _deathPrefab;
        
        private Rigidbody2D _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody2D>();

            _rigid.isKinematic = true;
        }

        // Game Events
        public void Activate()
        {
            _rigid.isKinematic = false;
            Jump(2);
        }

        public void OnHookRelease()
        {
            Jump();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent <Deadly>())
            {
                var deathPosition = transform.position;
                CoreEvents.HeroDiedAction(deathPosition);
                Instantiate(_deathPrefab, deathPosition, Quaternion.identity);
                Destroy(gameObject);
            }

            if (collision.gameObject.GetComponent<Goal>())
            {
                _rigid.isKinematic = true;
                _rigid.velocity = Vector3.zero;
                Destroy(gameObject);
                CoreEvents.HeroReachedGoalEvent();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Star star = collision.gameObject.GetComponent<Star>();
            if (star)
            {
                CoreEvents.StarCollectedEvent(star.transform.position);
                star.DestroyStar();
            }
        }

        private void Jump(float multiplier = 1f)
        {
            if (!PlayerIsCheating())
            {
                Vector2 jumpVector = Vector2.up * _jumpForce * multiplier;
                _rigid.AddForce(jumpVector, ForceMode2D.Impulse);
            }
        }

        private bool PlayerIsCheating()
        {
            // TODO: Return true if user clicks fast to gain height.
            return false;
        }
    }
}
