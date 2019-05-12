using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Vector3 startPosition;

    private Rigidbody2D rigid;
    public float jumpForce = 1.5f;
    private GameManager gameManager;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Jump(2);
    }

    internal void ResetPosition()
    {
        transform.position = startPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void OnHookRelease()
    {
        Jump();
    }

    private void Jump(float multiplier=1f)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ferr2DT_PathTerrain>())
            gameManager.OnHeroDeath();

        if (collision.gameObject.GetComponent<Goal>())
        {
            gameManager.OnHeroReachedGoal();
            rigid.isKinematic = true;
            rigid.velocity = Vector3.zero;
        }
    }
}
