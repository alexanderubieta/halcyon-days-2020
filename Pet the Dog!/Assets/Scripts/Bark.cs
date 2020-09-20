using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    private bool hasBarked = false;
    public AudioSource barkSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (hasBarked == false)
            {
                barkSFX.Play();
                hasBarked = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hasBarked = false;
        }
    }

    /* 
     * Test to see if barking works. Press E to play a bark!
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            myBark.Play();
        }
    }
    */
}
