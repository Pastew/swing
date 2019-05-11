using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject hookGO;
    private Hero hero;

    public void FindGameObjects()
    {
        hookGO = FindObjectOfType<Hook>().gameObject;
        hero = FindObjectOfType<Hero>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            hero.ResetPosition();
            hookGO.GetComponent<Hook>().ResetPosition();
        }

        if (Input.GetMouseButtonDown(0))
        {
            hookGO.transform.position = GetNewHookPosition();
            hookGO.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hookGO.SetActive(false);
            hero.OnHookRelease();
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
