﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public AudioSource gotFoodSFX;
    public AudioSource healSFX;
    private bool isColliding = false;

    void Awake()
    {
    }

    void Update()
    {
        isColliding = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gotFoodSFX.Play();
            healSFX.Play();
            other.GetComponent<PlayerHealth>().arms += 1; // Add an arm from the Player
            Destroy(gameObject);

        }
    }
}
