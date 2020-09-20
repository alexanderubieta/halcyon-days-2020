﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public AudioSource doggySFX;
    private bool isColliding = false;
    private HazardManager hm;
    private Animator dogANIM;

    void Awake()
    {
        dogANIM = gameObject.GetComponent<Animator>();
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void OnEnable()
    {
        dogANIM.SetInteger("dogNum", Random.Range(1, 10));
    }

    void Update()
    {
        isColliding = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doggySFX.Play();

            // WIN THE GAME!
            if (isColliding) return;
            isColliding = true;
            SceneManager.LoadScene("WinScene");
        }
    }
}
