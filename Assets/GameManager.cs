using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Hero hero;
    private Hook hook;

    private void Awake()
    {
        hero = FindObjectOfType<Hero>();
        hook = FindObjectOfType<Hook>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    internal void OnHeroDeath()
    {
        hook.gameObject.SetActive(true);
        hook.ResetPosition();

        hero.ResetPosition();
    }

    internal void OnHeroReachedGoal()
    {
        print("Win");
    }
}
