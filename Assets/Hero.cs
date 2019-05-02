using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float jumpForce = 1.5f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnHookRelease()
    {
        Jump();
    }

    private void Jump()
    {
        if (!PlayerIsCheating())
        {
            Vector2 jumpVector = Vector2.up * jumpForce;
            rigid.AddForce(jumpVector, ForceMode2D.Impulse);
        }
    }

    private bool PlayerIsCheating()
    {
        // TODO: Return true if user clicks fast to gain height.
        return false;
    }
}
