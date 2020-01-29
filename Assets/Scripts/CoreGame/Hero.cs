using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // External dependencies
    private GameManager gameManager;

    // Parameters
    public float jumpForce = 1.5f;

    // Components
    private Rigidbody2D rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

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
            gameManager.OnHeroDeath();
        }

        if (collision.gameObject.GetComponent<Goal>())
        {
            gameManager.OnHeroReachedGoal();
            rigid.isKinematic = true;
            rigid.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusPoint bonusPoint = collision.gameObject.GetComponent<BonusPoint>();
        if (bonusPoint)
        {
            gameManager.OnBonusPointCollected(bonusPoint);
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
