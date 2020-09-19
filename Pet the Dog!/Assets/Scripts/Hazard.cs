using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject camera;
    public AudioSource damagedSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            damagedSFX.Play();
            other.GetComponent<PlayerHealth>().arms -= 1; // Remove an arm from the Player
            camera.GetComponent<CameraShake>().TriggerShake();

            if (gameObject.tag == "Hazard")
            {
                Destroy(gameObject); //Destroys the current object. Walls won't be destroyed though.
            }
        }
    }
}
