using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public AudioSource doggySFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doggySFX.Play();
            other.GetComponent<PlayerHealth>().arms += 1; // Add an arm from the Player
        }
    }
}
