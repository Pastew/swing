using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject hookGO;
    private Hero ball;

    void Start()
    {
        hookGO = FindObjectOfType<Hook>().gameObject;
        ball = FindObjectOfType<Hero>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ball.transform.position = new Vector2(-7, 4);
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            hookGO.transform.position = GetNewHookPosition();
            hookGO.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hookGO.SetActive(false);
            ball.OnHookRelease();
        }

        // Move hook after finger
        //if(hookGO.active && Input.GetMouseButton(0))
        //{
        //    hookGO.transform.position = GetNewHookPosition();
        //}
    }

    private Vector3 GetNewHookPosition()
    {
        Vector3 newHookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(newHookPos.x, newHookPos.y, 0);
    }
}
