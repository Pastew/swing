using DG.Tweening;
using UnityEngine;

namespace CoreGame
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 1.5f;
        [SerializeField] private float _disappearingDuration = 1;
        [SerializeField] private GameObject _deathPrefab;

        private Rigidbody2D _rigid;
        private CircleCollider2D _collider;
        private ParticleSystem _trail;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();

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
            if (collision.gameObject.GetComponent<Deadly>())
            {
                var deathPosition = transform.position;
                CoreEvents.HeroDiedAction(deathPosition);
                Instantiate(_deathPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            print("OnTriggerEnter2D");
            Star star = col.gameObject.GetComponent<Star>();
            if (star)
            {
                CoreEvents.StarCollectedEvent(star.transform.position);
                star.DestroyStar();
            }

            if (col.gameObject.GetComponentInParent<Goal>())
            {
                _rigid.isKinematic = true;
                _rigid.velocity = Vector3.zero;
                Destroy(_collider);
                Sequence seq = DOTween.Sequence();
                seq.Append(
                    transform.DOMove(col.gameObject.transform.parent.position, _disappearingDuration)
                    .SetEase(Ease.OutExpo));
                
                seq.Join(
                    transform.DOScale(Vector3.zero, _disappearingDuration)
                    .SetEase(Ease.OutExpo));

                seq.OnComplete(() =>
                {
                    CoreEvents.HeroReachedGoalEvent();
                    Destroy(gameObject);
                });
                
                seq.Play();
            }
        }

        private void Jump(float multiplier = 1f)
        {
            if (!PlayerIsCheating())
            {
                Vector2 jumpVector = _jumpForce * multiplier * Vector2.up;
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