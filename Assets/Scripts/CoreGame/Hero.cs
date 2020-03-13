using UnityEngine;

public class Hero : MonoBehaviour
{
    private MetaGameManager _metaGameManager;

    private Rigidbody2D rigid;
    public float jumpForce = 1.5f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _metaGameManager = FindObjectOfType<MetaGameManager>();

        rigid.isKinematic = true;
    }

    // Game Events
    public void OnCountdownFinished()
    {
        rigid.isKinematic = false;
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
            _metaGameManager.OnHeroDeath();
        }

        if (collision.gameObject.GetComponent<Goal>())
        {
            _metaGameManager.OnHeroReachedGoal();
            rigid.isKinematic = true;
            rigid.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.gameObject.GetComponent<Star>();
        if (star)
        {
            _metaGameManager.OnBonusPointCollected(star);
        }
    }

    // Others
    private void Jump(float multiplier = 1f)
    {
        if (!PlayerIsCheating())
        {
            Vector2 jumpVector = Vector2.up * jumpForce * multiplier;
            rigid.AddForce(jumpVector, ForceMode2D.Impulse);
        }
    }

    private bool PlayerIsCheating()
    {
        // TODO: Return true if user clicks fast to gain height.
        return false;
    }
}
